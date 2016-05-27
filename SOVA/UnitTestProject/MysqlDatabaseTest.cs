using System;
using System.Linq;
using DomainModel;
using Moq;
using MySqlDatabase;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTestProject
{
    public class MysqlDatabaseTest
    {

        public Mock<StackOverflowDbContext> DbContextMock;

        [SetUp]
        public void SetUp()
        {
            DbContextMock = new Mock<StackOverflowDbContext>();
        }

        [Test]
        public void VerifyIntegrityOfAnnotations_ByReturningSomethingFromEmpty_ReturnOk()
        {
            // Arrange
            var annotation = new Annotation
            {
                Id = 1,
                Body = "this is a test",
                PostId = 1,
                CommentId = 1,
                SearchUserId = 1,
                Post = new Post(),
                Comment = new Comment(),
                SearchUser = new SearchUser()
            };

            // Act
            DbContextMock.Object.Annotations.Add(annotation);

            // Assert
            Assert.AreEqual(DbContextMock.Object.Annotations.Find(annotation.Id).Body,annotation.Body);
        }

        // Outdated non-mock tests below

        [Test]
        public void SovaDbContextTestAnnotation()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Annotations.Count().Equals(0));
        }
        [Test]
        public void SovaDbContextTestAnswer()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Answers.Count().Equals(11392));
        }
        [Test]
        public void SovaDbContextTestComment()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Comments.Count().Equals(32042));
        }
        [Test]
        public void SovaDbContextTestPost()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Posts.Count().Equals(13629));
        }
        [Test]
        public void SovaDbContextTestQuestion()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Questions.Count().Equals(1620));
        }
        [Test]
        public void SovaDbContextTestSearch()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Searchs.Count().Equals(8));
        }
        [Test]
        public void SovaDbContextTestSearchUser()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.SearchUsers.Count().Equals(3));
        }
        [Test]
        public void SovaDbContextTestTag()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Tags.Count().Equals(1874));
        }
        [Test]
        public void SovaDbContextTestUser()
        {
            using (var db = new StackOverflowDbContext())
                Assert.That(db.Users.Count().Equals(16827));
        }

    }
}