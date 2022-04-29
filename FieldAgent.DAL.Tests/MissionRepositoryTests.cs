using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace FieldAgent.DAL.Tests
{
    public class MissionRepositoryTests
    {
        MissionRepository db;
        DBFactory dbf;

        Mission thing = new Mission()
        {
            AgencyID = 5,
            CodeName = "o=",
            StartDate = DateTime.Parse("1/15/2021"),
            ProjectedEndDate = DateTime.Parse("6/22/2019"),
        };

        Mission updatedThing = new Mission()
        {
            MissionID = 1,
            AgencyID = 3,
            CodeName = "fuck off",
            StartDate = DateTime.Parse("1/15/2019"),
            ProjectedEndDate = DateTime.Parse("6/22/2021"),
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider provider = new ConfigProvider();
            dbf = new DBFactory(provider.Config, FactoryMode.TEST);
            db = new MissionRepository(/*dbf*/);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void GetGets()
        {
            Assert.IsTrue(db.Get(1).Success);
        }

        [Test]
        public void GetByAgentGetsByAgent()
        {
            Assert.IsTrue(db.GetByAgent(1).Success);
        }

        [Test]
        public void InsertInserts()
        {
            Assert.IsTrue(db.Insert(thing).Success);
        }

        [Test]
        public void UpdateUpdates()
        {
            Assert.IsTrue(db.Update(updatedThing).Success);
        }

        [Test]
        public void DeleteDeletes()
        {
            Assert.IsTrue(db.Delete(1).Success);
        }
    }
}
