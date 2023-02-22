using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCodeBuilder
{
    public class ClassSyntax : ICodeSyntax
    {
        public ClassSyntax(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public AccessModifier AccessModifiers { get; set; }

        void ICodeSyntax.AppendSourceString(SourceStringBuilder ssb)
        {
            ssb.AppendLine("{0} class {1}", AccessModifiers.ToSourceString(), Name);
            ssb.OpenBracket();

            ssb.CloseBracket();
        }
    }
}
