using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace FieldAgent.DAL.Tests
{
    class SecurityClearanceRepositoryTests
    {
        SecurityClearanceRepository db;
        DBFactory dbf;

        [SetUp]
        public void Setup()
        {
            ConfigProvider provider = new ConfigProvider();
            dbf = new DBFactory(provider.Config, FactoryMode.TEST);
            db = new SecurityClearanceRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void GetGets()
        {
            Assert.IsTrue(db.Get(1).Success);
        }

        [Test]
        public void GetAllGetsAll()
        {
            Assert.AreEqual(5, db.GetAll().Data.Count);
        }
    }
}
