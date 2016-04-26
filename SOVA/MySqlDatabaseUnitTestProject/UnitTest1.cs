using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySqlDatabase;
using System.Linq;

namespace MySqlDatabaseUnitTestProject
{
    [TestClass]
    public class MovieDbContextTest
    {
        [TestMethod]
        public void MovieDbContextTestPost()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(13629, db.Posts.Count());
        }
        [TestMethod]
        public void MovieDbContextTestAnnotation()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(0, db.Annotations.Count());
        }
        [TestMethod]
        public void MovieDbContextTestAnswer()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(11392, db.Answers.Count());
        }
        [TestMethod]
        public void MovieDbContextTestComment()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(32042, db.Comments.Count());
        }
        [TestMethod]
        public void MovieDbContextTestFavorit()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(0, db.Favorites.Count());
        }
        [TestMethod]
        public void MovieDbContextTestLinkedPost()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(14544, db.LinkedPosts.Count());
        }
        [TestMethod]
        public void MovieDbContextTestQuestion()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(1620, db.Questions.Count());
        }
        [TestMethod]
        public void MovieDbContextTestSearch()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(7, db.Searchs.Count());
        }
        [TestMethod]
        public void MovieDbContextTestSearchUser()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(2, db.SearchUsers.Count());
        }
        [TestMethod]
        public void MovieDbContextTestTag()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(1874, db.Tags.Count());
        }
        [TestMethod]
        public void MovieDbContextTestTagPost()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(6813, db.TagPosts.Count());
        }
        [TestMethod]
        public void MovieDbContextTestUser()
        {
            using (var db = new StackOverflowDbContext())
                Assert.AreEqual(16827, db.Users.Count());
        }
    }
}
