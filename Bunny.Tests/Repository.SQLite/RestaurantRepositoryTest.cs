using Bunny.Repository.Schema;
using Bunny.Repository.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bunny.Tests
{
    [TestClass]
    public class RestaurantRepositoryTest
    {
        [TestMethod]
        public void restaurant_insert()
        {
            var dbModel = new RestaurantModel()
            {
                Name = "Test Restaurant"
            };

            var newId = new RestaurantRepository().Insert(dbModel);

            Assert.IsTrue(newId > 0);
        }

        [TestMethod]
        public void restaurant_select()
        {
            int id = 1;

            var dbModel = new RestaurantRepository().Select(id);

            Assert.IsTrue(dbModel.Id > 0);
        }

        [TestMethod]
        public void restaurant_select_list()
        {
            var dbModel = new RestaurantRepository().SelectList();

            Assert.IsTrue(dbModel.Count > 0);
        }
    }
}
