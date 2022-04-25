using NUnit.Framework;

namespace A.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var actor1 = new Actor("alla", 4, 100);
            var actor2 = new Actor("allan", 4, 100);
            var result = ActorComparer.Instance.Compare(actor1, actor2);
            Assert.Positive(result);
        }

        [Test]
        public void Test2()
        {
            var actor1 = new Actor("alla", 4, 100);
            var actor2 = new Actor("alla", 4, 100);
            var result = ActorComparer.Instance.Compare(actor1, actor2);
            Assert.Zero(result);
        }

        [Test]
        public void Test3()
        {
            var actor1 = new Actor("alla", 4, 100);
            var actor2 = new Actor("alla", 5, 100);
            var result = ActorComparer.Instance.Compare(actor1, actor2);
            Assert.Negative(result);
        }

        [Test]
        public void Test4()
        {
            var actor1 = new Actor("alla", 4, 101);
            var actor2 = new Actor("alla", 4, 100);
            var result = ActorComparer.Instance.Compare(actor1, actor2);
            Assert.Negative(result);
        }
    }
}