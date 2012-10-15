using System;
using System.Text.RegularExpressions;

namespace UnderlyingModel
{
    public class RegexMatcher
    {
        public RegexMatcher(Regex reg, Func<Match, string> fullMatch, string name, Func<Match,string> simplifiedMatch = null )
        {
            _reg = reg;
            _fullMatch = fullMatch;
            Name = name;
			//if the simplified match doesn't exist, we assume it's the same as the full match
	        _simplifiedMatch = (simplifiedMatch == null) ? _fullMatch : _simplifiedMatch = simplifiedMatch;
        }

	    public string GetFullMatch(string sig)
        {
            var match = _reg.Match(sig);
            return match.Success ? _fullMatch(match) : string.Empty;
        }

		public string GetSimplifiedMatch(string sig)
		{
			var match = _reg.Match(sig);
			return match.Success ? _simplifiedMatch(match) : string.Empty;
		}

		public bool IsMatchSuccessful(string sig)
		{
			return _reg.Match(sig).Success;
		}

        private readonly Regex _reg;
        private readonly Func<Match, string> _fullMatch;
		private readonly Func<Match, string> _simplifiedMatch;
        public string Name { get; private set;}
    }
}
