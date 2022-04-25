using NUnit.Framework;

namespace H.Tests
{
    public class Tests
    {
        [TestCase("1010", "1011", "10101")]
        [TestCase("1", "1", "10")]
        [TestCase("0", "1", "1")]
        [TestCase("0", "0", "0")]
        [TestCase("0", "10", "10")]
        [TestCase("10", "0", "10")]
        [TestCase("10", "1", "11")]
        [TestCase("111", "0", "111")]
        [TestCase("1101110101000001000100101000100101100010101100001111001101011111111", "10101001011000011110101111101000101111110111110011000101111000011000101001000010101000", "10101001011000100000011110010000111000011100110111110010001101111010100010101110100111")]
        public void Test1(string num1, string num2, string result)
        {
            var actual = H.GetResult(num1, num2);
            Assert.AreEqual(result, actual);
        }
    }
}