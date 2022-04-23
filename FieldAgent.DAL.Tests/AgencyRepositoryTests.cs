using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using NUnit.Framework;

namespace FieldAgent.DAL.Tests
{
    public class AgencyRepositoryTests
    {
        AgencyRepository db;
        DBFactory dbf;
        Agency FFA = new Agency
        {
            ShortName = "FFA",
            LongName = "Fake Fucking Agency"
        };

        Agency FFAUpdate = new Agency
        {
            AgencyID = 13,
            ShortName = "UFFA",
            LongName = "Updated Fake Fucking Agency"
        };

        Agency getTest = new Agency
        {
            AgencyID = 1,
            ShortName = "Villar",
            LongName = "Flashset"
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider provider = new ConfigProvider();
            dbf = new DBFactory(provider.Config, FactoryMode.TEST);
            db = new AgencyRepository(dbf);
        }

        [Test]
        public void TestGetOne()
        {
            Assert.AreEqual(getTest.ShortName, db.Get(1).Data.ShortName);
        }

        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(12, db.GetAll().Data.Count);
        }

        [Test]
        public void InsertInserts()
        {
            Assert.AreEqual(FFA, db.Insert(FFA).Data);
        }

        [Test]
        public void UpdateUpdates()
        {
            Assert.IsTrue(db.Update(FFAUpdate).Success);
        }

        [Test]
        public void DeleteDeletes()
        {
            Assert.IsTrue(db.Delete(FFAUpdate.AgencyID).Success);
        }
    }
}