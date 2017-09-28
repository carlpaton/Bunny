using Bunny.Common;
using Bunny.Repository.Schema;
using Bunny.Repository.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bunny.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void user_select()
        {
            var cellPhone = 820000000;
            var password = new Hash().Go("password1"); //"7C6A180B36896A0A8C02787EEAFB0E4C"

            var dbModel = new UserRepository().Select(cellPhone, password);

            Assert.IsTrue(dbModel.Id > 0);
        }

        [TestMethod]
        public void user_insert()
        {
            var password = new Hash().Go("password1"); //"7C6A180B36896A0A8C02787EEAFB0E4C"

            var dbModel = new UserModel()
            {
                CellPhone = 123456789,
                HasAccess = true,
                Name = "Name",
                Password = password,
                Surname = "Surname"
            };

            var newId = new UserRepository().Insert(dbModel);

            Assert.IsTrue(newId > 0);
        }
    }
}
