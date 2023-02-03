using NUnit.Framework;

namespace J.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var q = new Q();
            var result = q.Get();
            Assert.IsNull(result);
        }

        [Test]
        public void Test2()
        {
            var q = new Q();
            var result = q.Size();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test3()
        {
            var q = new Q();
            q.Put(1);
            var result = q.Size();
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test4()
        {
            var q = new Q();
            q.Put(5);
            var result = q.Get();
            var size = q.Size();
            Assert.AreEqual(5, result);
            Assert.AreEqual(0, size);
        }
    }
}