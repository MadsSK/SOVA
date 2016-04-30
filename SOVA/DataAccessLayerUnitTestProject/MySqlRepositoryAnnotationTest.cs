using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DataAccessLayer;
using DomainModel;

namespace DataAccessLayerUnitTestProject
{

    public class MySqlRepositoryAnnotationTest
    {
        private readonly IRepository _repository = new MySqlRepository();

        [Test]
        public void GetAnnotationsWithPagingCountTest()
        {
            Console.WriteLine(_repository.GetAnnotationsWithPaging(10, 0).Select(a => a.Id == 1));
            Assert.That(_repository.GetAnnotationsWithPaging(10, 0).Count().Equals(2));
        }
    }
}
    