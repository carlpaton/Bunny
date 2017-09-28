using Bunny.Repository.Schema;
using Bunny.Repository.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bunny.Tests.Repository.SQLite
{
    [TestClass]
    public class ScoreRepositoryTest
    {
        [TestMethod]
        public void score_insert()
        {
            var dbModel = new ScoreModel()
            {
                InsertDate = DateTime.Now,
                RestaurantId = 1,
                Taste = 4,
                Temperature = 5,
                Tomorrow = 6,
                UserId = 1
            };

            var newId = new ScoreRepository().Insert(dbModel);

            Assert.IsTrue(newId > 0);
        }

        [TestMethod]
        public void score_select()
        {
            int id = 1;

            var dbModel = new ScoreRepository().Select(id);

            Assert.IsTrue(dbModel.Id > 0);
        }

        [TestMethod]
        public void score_select_list()
        {
            var dbModel = new ScoreRepository().SelectList();

            Assert.IsTrue(dbModel.Count > 0);
        }
    }
}
