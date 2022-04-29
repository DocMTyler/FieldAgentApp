using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace FieldAgent.DAL.Tests
{
    public class AliasRepositoryTests
    {
        AliasRepository db;
        DBFactory dbf;

        Alias ffa = new Alias()
        {
            AgentID = 2,
            AliasName = "Tamiko",
            InterpolID = Guid.Parse("8ad8a649-e501-4f47-9f86-9cbb46c3044d"),
            Persona = "Vestibulum sed magna at nunc commodo place. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede."
        };

        Alias ffaUpdate = new Alias()
        {
            AliasID = 2,
            AgentID = 2,
            AliasName = "Jimbo",
            InterpolID = Guid.Parse("8ad8a649-e501-4f47-9f86-9cbb46c3044d"),
            Persona = "sed magna at nunc commodo place. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede."
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider provider = new ConfigProvider();
            dbf = new DBFactory(provider.Config, FactoryMode.TEST);
            db = new AliasRepository(/*dbf*/);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestGetGets()
        {
            Assert.AreEqual(ffa.AliasName, db.Get(2).Data.AliasName);
        }

        [Test]
        public void InsertInserts()
        {
            Assert.AreEqual(ffa, db.Insert(ffa).Data);
        }

        [Test]
        public void UpdateUpdates()
        {
            Assert.IsTrue(db.Update(ffaUpdate).Success);
        }

        [Test]
        public void DeleteDeletes()
        {
            Assert.IsTrue(db.Delete(3).Success);
        }

        [Test]
        public void GetByAgentGetsByAgent()
        {
            Assert.IsTrue(db.GetByAgent(1).Success);
        }
    }
}
