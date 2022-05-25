namespace P_01_09;

public class Class1
{
    public bool IsSubstring(string s1, string s2) =>
        s1.Length == s2.Length && (s1 + s1).Contains(s2);
}