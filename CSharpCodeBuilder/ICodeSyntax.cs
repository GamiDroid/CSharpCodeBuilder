using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCodeBuilder
{
    internal interface ICodeSyntax
    {
        void AppendSourceString(SourceStringBuilder ssb);
    }
}
