using MySqlDatabase;
using NUnit.Framework;

namespace DomainModelUnitTestProject
{
    public class DomainModelQuestionUnitTest
    {
        [Test]
        public void DomainModelQuestionGetAllRelationsTest()
        {
            using (var db = new SovaDBContext())
            {
                Assert.That(db.Question.Where().Equals());
            }
        }
    }
}
