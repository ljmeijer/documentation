using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BookBuilder
{
	internal class TOCBuilder
	{
		interface ITOCNode
		{
			void Write(TextWriter tw);
		}

		class TOCGroup : ITOCNode
		{
			private readonly List<ITOCNode> _children = new List<ITOCNode>();

			private readonly string Name;

			public TOCGroup(string name)
			{
				Name = name;
			}

			public void Write(TextWriter tw)
			{
				tw.Write("<h2>{0}</h2>",Name);
				tw.Write("<ul>");
				foreach(var child in _children)
					child.Write(tw);
				tw.Write("</ul>");
			}

			public void Add(ITOCNode tocPageNode)
			{
				_children.Add(tocPageNode);
			}

			public TOCGroup FindOrMake(string groupName)
			{
				var group = _children.OfType<TOCGroup>().FirstOrDefault(g => g.Name == groupName);
				if (group != null)
					return group;

				group = new TOCGroup(groupName);
				Add(group);
				return group;
			}
		}

		class TOCPage : ITOCNode
		{
			private readonly BookPage _page;

			public TOCPage(BookPage page)
			{
				_page = page;
			}

			public void Write(TextWriter tw)
			{
				tw.Write("<li>{0}</li>", _page.Title);
			}
		}

		private readonly List<BookPage> _pages;
		private readonly TOCGroup _rootNode;

		public TOCBuilder(List<BookPage> pages)
		{
			_pages = pages;
			_rootNode = new TOCGroup("Unity Book");
		}

		public string Build()
		{
			foreach (var page in _pages)
			{
				var tocParentName = page.GetTOCParent();
				
				tocParent.Add(new TOCPage(page));
			}

			var sw = new StringWriter();
			_rootNode.Write(sw);
			return sw.ToString();
		}
	}
}
