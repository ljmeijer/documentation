using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using YamlDotNet.RepresentationModel;

namespace BookBuilder
{
    internal class TOCBuilder
    {
        private readonly string _input;

        public TOCBuilder(string input)
        {
            _input = input;
        }

        public string Build()
        {
            var htmlwriter = new StringWriter();

            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(new StringReader(_input));

            // Examine the stream

            WriteHtmlForNode(yaml.Documents[0].RootNode, htmlwriter);
            
            return htmlwriter.ToString();


        }

        private static void WriteHtmlForNode(YamlNode item, StringWriter htmlwriter)
        {
            var scalar = item as YamlScalarNode;
            if (scalar != null)
                WriteHtmlForScalarNode(htmlwriter, scalar);

            var mapping = item as YamlMappingNode;
            if (mapping != null)
                WriteHtmlForMappingNode(htmlwriter, mapping);

            var sequence = item as YamlSequenceNode;
            if (sequence != null)
                WriteHtmlForSequenceNode(htmlwriter, sequence);
        }

        private static void WriteHtmlForScalarNode(StringWriter htmlwriter, YamlScalarNode scalar)
        {
            var regex = new Regex(@"(.*)\[(.*?)\]");
            
            var match = regex.Match(scalar.ToString());
            string href = null;
            string caption = scalar.ToString();

            if (match.Success)
            {
                caption = match.Groups[1].ToString();
                href = match.Groups[2] + ".html";
            }

            if (href != null)
                htmlwriter.Write("<a href='{0}'>", href);
    
            htmlwriter.Write(caption);
            
            if (href != null)
                htmlwriter.Write("</a>");
        }

        private static void WriteHtmlForSequenceNode(StringWriter htmlwriter, YamlSequenceNode sequence)
        {
            htmlwriter.Write("<ul>");
            foreach (var node in sequence)
            {
                htmlwriter.Write("<li>");
                WriteHtmlForNode(node, htmlwriter);
                htmlwriter.Write("</li>");
            }
            htmlwriter.Write("</ul>");
        }

        private static void WriteHtmlForMappingNode(StringWriter htmlwriter, YamlMappingNode mapping)
        {
            var keyValuePair = mapping.Children.Single();
            htmlwriter.Write(keyValuePair.Key);
            WriteHtmlForNode(keyValuePair.Value, htmlwriter);
        }
    }
}
    