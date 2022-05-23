using System.Text;

namespace P_01_03;

public class Class1
{
    public string ReplaceSpaces(string s)
    {
        var spaces = s.Count(x => x == ' ');
        var output = new char[s.Length + spaces * 2];
        var outputPos = 0;

        foreach (var ch in s)
        {
            if (ch == ' ')
            {
                output[outputPos] = '%';
                output[outputPos + 1] = '2';
                output[outputPos + 2] = '0';
                outputPos += 3;
            }
            else
            {
                output[outputPos] = ch;
                outputPos += 1;
            }
        }

        return new string(output);
    }
}