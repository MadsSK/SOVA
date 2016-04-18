using System;
using MySqlDatabase;
using System.Linq;
using NUnit.Framework;

namespace MySqlDatabaseUnitTestProject
{
    
    public class SovaDbContextTest
    {
        [Test]
        public void SovaDbContextTestAnnotation()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Annotations.Count().Equals(0));
        }
        [Test]
        public void SovaDbContextTestAnswer()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Answers.Count().Equals(11392));
        }
        [Test]
        public void SovaDbContextTestComment()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Comments.Count().Equals(32042));
        }
        [Test]
        public void SovaDbContextTestPost()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Posts.Count().Equals(13629));
        }
        [Test]
        public void SovaDbContextTestQuestion()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Questions.Count().Equals(1620));
        }
        [Test]
        public void SovaDbContextTestSearch()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Searchs.Count().Equals(8));
        }
        [Test]
        public void SovaDbContextTestSearchUser()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.SearchUsers.Count().Equals(3));
        }
        [Test]
        public void SovaDbContextTestTag()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Tags.Count().Equals(1874));
        }
        [Test]
        public void SovaDbContextTestUser()
        {
            using (var db = new SovaDBContext())
                Assert.That(db.Users.Count().Equals(16827));
        }
    }
}
