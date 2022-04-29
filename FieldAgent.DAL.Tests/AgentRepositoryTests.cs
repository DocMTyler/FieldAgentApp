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
using Microsoft.EntityFrameworkCore;

namespace FieldAgent.DAL.Tests
{
    public class AgentRepositoryTests 
    {
        AgentRepository db;
        DBFactory dbf;

        Agent ffa = new Agent()
        {
            FirstName = "Vinson",
            LastName = "Leechman",
            DateOfBirth = DateTime.Parse("3/27/2007"),
            Height = 5.85m
        };

        Agent ffaUpdate = new Agent()
        {
            AgentID = 5,
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
            db = new AgentRepository(/*dbf*/);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void DeleteDeletes()
        {
            Assert.IsTrue(db.Delete(1).Success);
        }

        [Test]
        public void GetGets()
        {
            Assert.AreEqual(ffa.LastName, db.Get(1).Data.LastName);
        }

        [Test]
        public void GetMissionsGetsMissions()
        {
            Assert.IsTrue(db.GetMissions(1).Success);
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
