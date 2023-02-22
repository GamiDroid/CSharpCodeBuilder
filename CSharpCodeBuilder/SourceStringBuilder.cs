using System.Text;

namespace CSharpCodeBuilder
{
    internal class SourceStringBuilder
    {
        public char IndentChar { get; set; } = '\t';
        public int IndentMultiplier { get; set; } = 1;

        /// <summary>
        /// Append a new line to the builder.
        /// </summary>
        /// <param name="text">Text to append.</param>
        public void AppendLine(string? text = null)
        {
            if (!string.IsNullOrWhiteSpace(text))
                _sb.Append(IndentChar, _indent * IndentMultiplier);
            _sb.AppendLine(text);
        }

        public void AppendLine(string format, params object[] args)
        {
            this.AppendLine(string.Format(format, args));
        }

        /// <summary>
        /// Increases the indent.
        /// </summary>
        /// <param name="indent">Increase the indent by how many.</param>
        public void IncreaseIndent(int indent = 1) => _indent += indent;

        /// <summary>
        /// Decreases the indent.
        /// </summary>
        /// <param name="indent">Descrease the indent by how many.</param>
        public void DecreaseIndent(int indent = 1)
        {
            _indent -= indent;
            if (_indent < 0) _indent = 0;
        }

        /// <summary>
        /// Creates a new line with a bracket '{', and then increases the indent with one.
        /// </summary>
        public void OpenBracket()
        {
            AppendLine("{");
            IncreaseIndent();
        }

        /// <summary>
        /// First decreases the indent by one then appends a line with a closing bracket '}'.
        /// </summary>
        public void CloseBracket()
        {
            DecreaseIndent();
            AppendLine("}");
        }

        /// <summary>
        /// Convert the build source code into a string.
        /// </summary>
        /// <returns>The builded source code.</returns>
        public override string ToString() => _sb.ToString();

        private int _indent = 0;
        private readonly StringBuilder _sb = new StringBuilder();
    }
}
