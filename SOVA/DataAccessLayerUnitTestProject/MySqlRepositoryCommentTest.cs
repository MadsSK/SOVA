using System;
using System.Linq;
using NUnit.Framework;
using DataAccessLayer;
using DomainModel;

namespace DataAccessLayerUnitTestProject
{

    public class MySqlRepositoryCommentTest
    {
        private readonly IRepository _repository = new MySqlRepository();

        [Test]
        public void GetCommentIDTest()
        {
            Assert.That(_repository.GetComment(120).Id.Equals(120));
        }

        [Test]
        public void GetCommentPostIdTest()
        {
            Assert.That(_repository.GetComment(120).PostId.Equals(39433));
        }

        [Test]
        public void GetCommentScoreTest()
        {
            Assert.That(_repository.GetComment(120).Score.Equals(1));
        }

        [Test]
        public void GetCommentTextTest()
        {
            Assert.That(
                _repository.GetComment(120)
                    .Text.Equals(
                        @"I'd almost hope people not know about this feature. Far preferable that they organise their code into smaller, more meaningful methods and simply use `return`, in most cases. There is a great furore at the moment around this language construct being added to PHP6."));
        }

        [Test]
        public void GetCommentCreateDateTest()
        {
            Assert.That(_repository.GetComment(120).CreateDate.Equals(
                new DateTime(2008, 09, 07, 15, 28, 46)));
        }

        [Test]
        public void GetCommentUserIdTest()
        {
            Assert.That(_repository.GetComment(120).UserId.Equals(1820));
        }

        [Test]
        public void GetCommentTest()
        {
            Assert.That(_repository.GetComment(120).Equals(
                new
                {
                    Id = 120,
                    PostId = 39433,
                    Score = 1,
                    Text =
                       "I'd almost hope people not know about this feature. Far preferable that they organise their code into smaller, more meaningful methods and simply use `return`, in most cases. There is a great furore at the moment around this language construct being added to PHP6.",
                    CreateDate = new DateTime(2008, 09, 07, 15, 28, 46),
                    UserId = 1820
                }), _repository.GetComment(120).Text);
        }

        [Test]
        public void GetCommentsTest()
        {
            Assert.That(_repository.GetComments("java").Count().Equals(1069), _repository.GetPosts("java").Count().ToString());

        }
    }
}
