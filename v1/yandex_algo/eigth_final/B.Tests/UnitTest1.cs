// using NUnit.Framework;
//
// namespace B.Tests
// {
//     public class Tests
//     {
//         [Test]
//         public void Test1()
//         {
//             var words = new[]
//             {
//                 "will",
//                 "pass",
//                 "the",
//                 "exam",
//                 "i",
//             };
//             var dict = CreateTrie(words);
//             var text = "examiwillpasstheexam";
//             Assert.True(B.CanSplit(dict, text, 0, new bool[text.Length]));
//         }
//
//         [Test]
//         public void Test2()
//         {
//             var words = new[]
//             {
//                 "abac",
//                 "caba",
//             };
//             var dict = CreateTrie(words);
//             var text = "abacaba";
//             Assert.False(B.CanSplit(dict, text, 0, new bool[text.Length]));
//         }
//
//         [Test]
//         public void Test3()
//         {
//             var words = new[]
//             {
//                 "abac",
//                 "caba",
//                 "aba",
//             };
//             var dict = CreateTrie(words);
//             var text = "abacaba";
//             Assert.True(B.CanSplit(dict, text, 0, new bool[text.Length]));
//         }
//
//         [Test]
//         public void Test4()
//         {
//             var words = new[]
//             {
//                 "ab",
//                 "abaca",
//                 "acaba",
//             };
//             var dict = CreateTrie(words);
//             var text = "abacaba";
//             Assert.True(B.CanSplit(dict, text, 0, new bool[text.Length]));
//         }
//
//         private static Trie CreateTrie(string[] words)
//         {
//             var trie = new Trie();
//             foreach (var word in words)
//                 trie.Add(word);
//             return trie;
//         }
//     }
// }