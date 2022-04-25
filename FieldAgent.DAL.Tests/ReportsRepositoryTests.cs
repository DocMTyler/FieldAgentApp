using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace FieldAgent.DAL.Tests
{
    public class ReportsRepositoryTests
    {
        ReportsRepository db;
        DBFactory dbf;
        
        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DBFactory(cp.Config, FactoryMode.TEST);
            db = new ReportsRepository(cp.Config);
            //dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void TestAuditClearance()
        {
            Assert.IsTrue(db.AuditClearance(1, 1).Success);
        }

        [Test]
        public void TestPensionList()
        {
            Assert.IsTrue(db.GetPensionList(1).Success);
        }

        [Test]
        public void TestTopAgents()
        {
            Assert.IsTrue(db.GetTopAgents().Success);
        }
    }
}
