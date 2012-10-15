using System.Collections.Generic;

namespace UnderlyingModel
{
	public class MultiDict<TKey, TValue> // no (collection) base class
	{
		private Dictionary<TKey, List<TValue>> _data = new Dictionary<TKey, List<TValue>>();

		public void Add(TKey k, TValue v)
		{
			// can be a optimized a little with TryGetValue, this is for clarity
			if (_data.ContainsKey(k))
				_data[k].Add(v);
			else
				_data.Add(k, new List<TValue> {v});
		}

		public bool Contains(TKey k)
		{
			return _data.ContainsKey(k);
		}

		public List<TValue> Values(TKey k)
		{
			return _data[k];
		}

		public int CountValuesForThisKey(TKey k)
		{
			return _data[k].Count;
		}

		public void RemoveKey(TKey k)
		{
			if (_data.ContainsKey(k))
				_data.Remove(k);
		}

		public Dictionary<TKey, List<TValue>>.KeyCollection Keys
		{
			get { return _data.Keys; }
		}
}
}
