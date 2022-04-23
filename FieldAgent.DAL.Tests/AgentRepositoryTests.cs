using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.DAL.Repositories;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.Tests
{
    public class AgentRepositoryTests 
    {
        AgentRepository db;
        DBFactory dbf;

        Agent ffa = new Agent()
        {
            FirstName = "Trenton",
            LastName = "Pattle",
            DateOfBirth = DateTime.Parse("1/1/2000"),
            Height = 0.83m
        };

        Agent ffaUpdate = new Agent()
        {
            AgentID = 11,
            FirstName = "Trent",
            LastName = "Patty",
            DateOfBirth = DateTime.Parse("1/11/2000"),
            Height = 0.88m
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider provider = new ConfigProvider();
            dbf = new DBFactory(provider.Config, FactoryMode.TEST);
            db = new AgentRepository(dbf);
        }

        [Test]
        public void DeleteDeletes()
        {
            Assert.IsTrue(db.Delete(ffaUpdate.AgentID).Success);
        }

        [Test]
        public void GetGets()
        {
            Assert.AreEqual(ffa.LastName, db.Get(1).Data.LastName);
        }

        [Test]
        public void GetMissionsGetsMissions()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void InsertInserts()
        {
            Assert.AreEqual(ffa, db.Insert(ffa).Data);
        }

        [Test]
        public void Update()
        {
            Assert.IsTrue(db.Update(ffaUpdate).Success);
        }
    }
}
