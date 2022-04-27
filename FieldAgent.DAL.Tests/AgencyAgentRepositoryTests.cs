using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace FieldAgent.DAL.Tests
{
    class AgencyAgentRepositoryTests
    {
        AgencyAgentRepository db;
        DBFactory dbf;

        AgencyAgent fFAA = new AgencyAgent()
        {
            AgencyID = 1,
            AgentID = 1,
            SecurityClearanceID = 1,
            BadgeID = Guid.Parse("9e716ed6-87f8-48b3-8a97-bcd8051eb981"),
            ActivationDate = DateTime.Parse("2/23/2022"),
            DeactivationDate = DateTime.Parse("8/24/2021"),
            IsActive = Convert.ToBoolean(1)
        };

        AgencyAgent fFAAUpdate = new AgencyAgent()
        {
            AgencyID = 4,
            AgentID = 7,
            SecurityClearanceID = 1,
            BadgeID = Guid.Parse("f7293524-21a8-4f37-bbb0-f1a38330ab81"),
            ActivationDate = DateTime.Parse("2/24/2022"),
            DeactivationDate = DateTime.Parse("9/24/2021"),
            IsActive = Convert.ToBoolean(0)
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider provider = new ConfigProvider();
            dbf = new DBFactory(provider.Config, FactoryMode.TEST);
            db = new AgencyAgentRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestGetGets()
        {
            Assert.AreEqual(fFAA.BadgeID, db.Get(1, 1).Data.BadgeID);
        }

        [Test]
        public void InsertInserts()
        {
            Assert.AreEqual(fFAA, db.Insert(fFAA).Data);
        }

        [Test]
        public void UpdateUpdates()
        {
            Assert.IsTrue(db.Update(fFAAUpdate).Success);
        }

        [Test]
        public void DeleteDeletes()
        {
            Assert.IsTrue(db.Delete(1, 1).Success);
        }

        [Test]
        public void GetByAgencyGetsByAgency()
        {
            Assert.IsTrue(db.GetByAgency(9).Success);
        }

        [Test]
        public void GetByAgentGetsByAgent()
        {
            Assert.IsTrue(db.GetByAgent(5).Success);
        }
    }
}

