using System;
using System.Text;

namespace Sharp.Xmpp
{
    internal class SecurityElement
    {
        private static readonly String[] s_escapeStringPairs = new String[]
            {
                // these must be all once character escape sequences or a new escaping algorithm is needed
                "<", "&lt;",
                ">", "&gt;",
                "\"", "&quot;",
                "\'", "&apos;",
                "&", "&amp;"
            };

        private static readonly char[] s_escapeChars = new char[] { '<', '>', '\"', '\'', '&' };
        private static String GetEscapeSequence(char c)
        {
            int iMax = s_escapeStringPairs.Length;

            for (int i = 0; i < iMax; i += 2)
            {
                String strEscSeq = s_escapeStringPairs[i];
                String strEscValue = s_escapeStringPairs[i + 1];

                if (strEscSeq[0] == c)
                    return strEscValue;
            }
            
            return c.ToString();
        }

        public static String Escape(String str)
        {
            if (str == null)
                return null;

            StringBuilder sb = null;

            int strLen = str.Length;
            int index; // Pointer into the string that indicates the location of the current '&' character
            int newIndex = 0; // Pointer into the string that indicates the start index of the "remaining" string (that still needs to be processed).


            do
            {
                index = str.IndexOfAny(s_escapeChars, newIndex);

                if (index == -1)
                {
                    if (sb == null)
                        return str;
                    else
                    {
                        sb.Append(str, newIndex, strLen - newIndex);
                        return sb.ToString();
                    }
                }
                else
                {
                    if (sb == null)
                        sb = new StringBuilder();

                    sb.Append(str, newIndex, index - newIndex);
                    sb.Append(GetEscapeSequence(str[index]));

                    newIndex = (index + 1);
                }
            }
            while (true);

            // no normal exit is possible
        }
    }
}