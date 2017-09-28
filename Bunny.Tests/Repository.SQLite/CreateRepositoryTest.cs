using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunny.Repository.SQLite;

namespace Bunny.Tests
{
    [TestClass]
    public class CreateRepositoryTest
    {
        [TestMethod]
        public void create_structure()
        {
            new DropAndCreateRepository().User();
            new DropAndCreateRepository().Restaurant();
            new DropAndCreateRepository().Score();

            //probably should assert something \:D/
        }

        [TestMethod]
        public void seed_db()
        {
            new SeedRepository().User();
            new SeedRepository().Restaurant();
            new SeedRepository().Score();

            //probably should assert something \:D/
        }
    }
}
