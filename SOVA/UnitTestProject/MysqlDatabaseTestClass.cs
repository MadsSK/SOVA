using NUnit.Framework;

namespace UnitTestProject
{
    public class MysqlDatabaseTestClass
    {
        [Test]
        public void TestTesting()
        {
            Assert.That(Jonas.IsCool);
            
        }

        private static class Jonas
        {
            public const bool IsCool = true;
        }
    }
}