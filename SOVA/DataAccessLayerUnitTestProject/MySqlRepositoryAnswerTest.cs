using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DataAccessLayer;
using DomainModel;

namespace DataAccessLayerUnitTestProject
{

    public class MySqlRepositoryAnswerTest
    {
        private readonly IRepository _repository = new MySqlRepository();

        [Test]
        public void GetAnswerByIdTest()
        {
            Assert.That(_repository.GetAnswer(71).Id.Equals(71));
        }

        [Test]
        public void CountNumberOfTagsInAnswer71Test()
        {
            Assert.That(_repository.GetAnswer(71).Tags.Count.Equals(1874));
        }

        [Test]
        public void GetNumberOfAnswersTest()
        {
            Assert.That(_repository.GetNumberOfAnswers().Equals(234));
        }

        [Test]
        public void GetAnswersTest()
        {
            Assert.That(_repository.GetAnswers("java").Equals(234));    
        }

        [Test]
        public void GetAnswersWithPagingTest()
        {
            Assert.That(_repository.GetAnswersWithPaging(0,10).Equals(10));    
        }
        

    }
}
    