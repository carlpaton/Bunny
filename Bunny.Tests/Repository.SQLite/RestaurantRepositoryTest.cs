using System.Collections.Generic;
using Bunny.Repository.Interface;
using Bunny.Repository.Schema;
using Bunny.Repository.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bunny.Tests
{
    [TestClass]
    public class RestaurantRepositoryTest : IRestaurantRepository
    {
        [TestMethod]
        public void RestaurantRepository_Insert()
        {
            Insert(null);
        }

        [TestMethod]
        public void RestaurantRepository_Select()
        {
            Select(1);
        }

        [TestMethod]
        public void RestaurantRepository_SelectList()
        {
            SelectList();
        }

        #region IRestaurantRepository
        public int Insert(RestaurantModel obj)
        {
            // arrange
            var dbModel = new RestaurantModel()
            {
                Name = "Test Restaurant"
            };

            // act 
            var newId = new RestaurantRepository().Insert(dbModel);

            // assert 
            Assert.IsTrue(newId > 0);

            return newId;
        }

        public RestaurantModel Select(int id)
        {
            // arrange
            int _id = id;

            // act 
            var dbModel = new RestaurantRepository().Select(_id);

            // assert 
            Assert.IsTrue(dbModel.Id > 0);

            return dbModel;
        }

        public List<RestaurantModel> SelectList()
        {
            // arrange
            // act 
            var dbModel = new RestaurantRepository().SelectList();

            // assert 
            Assert.IsTrue(dbModel.Count > 0);

            return dbModel;
        }
        #endregion
    }
}
