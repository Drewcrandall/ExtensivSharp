using System;
using System.Collections.Generic;
using System.Text;

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

        public string Build()
        {
            var andSegment = string.Join(";", _andClauses);
            var orSegment = string.Join(",", _orClauses);
            if (!string.IsNullOrWhiteSpace(andSegment) && !string.IsNullOrWhiteSpace(orSegment))
                return $"{andSegment};({orSegment})";
            return andSegment + orSegment;
        }

        private string Escape(string value)
        {
            return Uri.EscapeDataString(value
                .Replace("%", "%25")
                .Replace("!", "%21")
                .Replace("(", "%28")
                .Replace(")", "%29")
                .Replace("*", "%2A")
                .Replace("=", "%3D")
                .Replace(",", "%2C")
                .Replace(";", "%3B")
            );
        }
    }

}
