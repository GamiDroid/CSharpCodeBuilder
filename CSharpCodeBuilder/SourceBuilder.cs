using System;
using System.Collections.Generic;

namespace CSharpCodeBuilder
{
    public class SourceBuilder
    {
        public SourceBuilder(string namespaceName)
        {
            _namespace = namespaceName;
        }

        public SourceBuilder AddUsings(params string[] usings)
        {
            foreach (var u in usings)
            {
                if (!string.IsNullOrWhiteSpace(u))
                    _usings.Add(u.Trim());
            }
            return this;
        }

        public SourceBuilder AddHeaderComment(string header)
        {
            _headerComments.Add(header);
            return this;
        }

        public SourceBuilder AddClass(ClassSyntax classSyntax)
        {
            _codeSyntaxes.Add(classSyntax);
            return this;
        }

        public override string ToString()
        {
            var ssb = new SourceStringBuilder();

            foreach (var c in _headerComments)
                ssb.AppendLine("//{0}", c);

            foreach (var u in _usings)
                ssb.AppendLine("using {0};", u);

            ssb.AppendLine("namespace {0}", _namespace);
            ssb.OpenBracket();

            foreach (var cs in _codeSyntaxes)
            {
                cs.AppendSourceString(ssb);
            }

            ssb.CloseBracket();

            return ssb.ToString();
        }

        private SourceBuilder AddCode(ICodeSyntax codeSyntax)
        {
            if (codeSyntax != null)
                _codeSyntaxes.Add(codeSyntax);
            return this;
        }

        private readonly HashSet<string> _usings = new HashSet<string>();
        private readonly ICollection<string> _headerComments = new List<string>();
        private readonly string _namespace;
        private readonly ICollection<ICodeSyntax> _codeSyntaxes = new List<ICodeSyntax>();
    }
}
