using System;
using MySqlDatabase;
using System.Linq;
using NUnit.Framework;

namespace MySqlDatabaseUnitTestProject
{
    
    public class SovaDbContextTest
    {
        [Test]
        public void SovaDbContextTestPost()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(13629, db.Posts.Count());
        }
        [Test]
        public void SovaDbContextTestAnnotation()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(0, db.Annotations.Count());
        }
        [Test]
        public void SovaDbContextTestAnswer()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(11392, db.Answers.Count());
        }
        [Test]
        public void SovaDbContextTestComment()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(32042, db.Comments.Count());
        }
        [Test]
        public void SovaDbContextTestFavorit()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(0, db.Favorites.Count());
        }
        [Test]
        public void SovaDbContextTestLinkedPost()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(14544, db.LinkedPosts.Count());
        }
        [Test]
        public void SovaDbContextTestQuestion()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(1620, db.Questions.Count());
        }
        [Test]
        public void SovaDbContextTestSearch()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(7, db.Searchs.Count());
        }
        [Test]
        public void SovaDbContextTestSearchUser()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(2, db.SearchUsers.Count());
        }
        [Test]
        public void SovaDbContextTestTag()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(1874, db.Tags.Count());
        }
        [Test]
        public void SovaDbContextTestTagPost()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(6813, db.TagPosts.Count());
        }
        [Test]
        public void SovaDbContextTestUser()
        {
            using (var db = new SovaDBContext())
                Assert.AreEqual(16827, db.Users.Count());
        }
    }
}
