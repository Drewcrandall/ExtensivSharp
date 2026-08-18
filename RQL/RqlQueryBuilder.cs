namespace ExtensivSharp.RQL
{
    public class RqlQueryBuilder
    {
        private readonly List<string> _andClauses = new();
        private readonly List<string> _orClauses = new();

        public RqlQueryBuilder Where(string field, string op, string value)
        {
            _andClauses.Add($"{field}{op}{Escape(value)}");
            return this;
        }

        public RqlQueryBuilder Or(string field, string op, string value)
        {
            _orClauses.Add($"{field}{op}{Escape(value)}");
            return this;
        }

        public RqlQueryBuilder In(string field, params string[] values)
        {
            var encoded = string.Join(",", values.Select(Escape));
            _andClauses.Add($"{field}=in=({encoded})");
            return this;
        }

        public RqlQueryBuilder NotIn(string field, params string[] values)
        {
            var encoded = string.Join(",", values.Select(Escape));
            _andClauses.Add($"{field}=out=({encoded})");
            return this;
        }

        public RqlQueryBuilder HasValue(string field, bool hasValue)
        {
            _andClauses.Add($"{field}=hv={hasValue.ToString().ToLower()}");
            return this;
        }

        /// <summary>
        /// Returns the raw RQL expression. This is not URL encoded - pass it through
        /// <see cref="Uri.EscapeDataString(string)"/> exactly once when placing it in a query string.
        /// </summary>
        public string Build()
        {
            var andSegment = string.Join(";", _andClauses);
            var orSegment = string.Join(",", _orClauses);
            if (!string.IsNullOrWhiteSpace(andSegment) && !string.IsNullOrWhiteSpace(orSegment))
                return $"{andSegment};({orSegment})";
            return andSegment + orSegment;
        }

        /// <summary>
        /// Applies RQL-level escaping to a predicate value, per the "Character Escape Sequences"
        /// rules in Extensiv's RQL documentation. This is deliberately NOT URL encoding: it converts
        /// the eight RQL-significant characters to percent sequences so the server's RQL parser sees
        /// them as data rather than syntax. The single URL encode applied by the calling endpoint
        /// then turns each "%" into "%25", which is exactly the two-layer form the documentation
        /// specifies (intent x;y -> RQL x%3By -> wire x%253By).
        /// Note "*" is escaped, so values always match literally; the builder has no wildcard syntax.
        /// </summary>
        private static string Escape(string value)
        {
            return value
                .Replace("%", "%25")
                .Replace("!", "%21")
                .Replace("(", "%28")
                .Replace(")", "%29")
                .Replace("*", "%2A")
                .Replace("=", "%3D")
                .Replace(",", "%2C")
                .Replace(";", "%3B");
        }
    }

}
