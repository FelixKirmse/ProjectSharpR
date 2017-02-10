// Copyright © Anton Paar GmbH, 2017

using System.Text;

namespace ProjectR.Interfaces.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendNewLine(this StringBuilder sb)
        {
            return sb.Append("\n");
        }

        public static StringBuilder AppendNewLine(this StringBuilder sb, string text)
        {
            return sb.Append(text).AppendNewLine();
        }
    }
}