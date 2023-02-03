using System.Text;

namespace ReverseWordsInString;

public class Solution
{
    public string ReverseWords(string s)
    {
        // return string.Join(' ', s.Trim().Split(' ').Where(x => x.Length > 0).Reverse());

        var sb = new StringBuilder();

        var l = s.Length - 1;
        var r = l;
        for (var i = r; i >= 0; i--)
        {
            switch (s[i])
            {
                case ' ':
                    if (r-l>0) { 
                        sb.Append(s.AsSpan(l+1, r-l));
                    }
                    l=i-1;
                    r=i-1;
                    break;

                default:
                    l--;
                    break;
            }
        }

        void AppendWord()
        {
            
        }

        return sb.ToString();
    }
}