using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace FieldAgent.DAL.Tests
{
    public class LocationRepositoryTests
    {
        LocationRepository db;
        DBFactory dbf;

        [SetUp]
        public void Setup()
        {
            ConfigProvider provider = new ConfigProvider();
            dbf = new DBFactory(provider.Config, FactoryMode.TEST);
            db = new LocationRepository(dbf);
            //dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        Location place = new Location()
        {
            //LocationID = 8,
            AgencyID = 2,
            LocationName = "ÃŽle-de-France",
            Street1 = "4659 Sunbrook Avenue",
            Street2 = "4985 Arizona Parkway",
            City = "Paris 09",
            PostalCode = "12345",
            CountryCode = "A8"
        };

        Location updatePlace = new Location()
        {
            LocationID = 8,
            AgencyID = 2,
            LocationName = "Some shit-de-France",
            Street1 = "4659 Sunbrook Avenue",
            Street2 = "4985 Arizona Parkway",
            City = "Paris 09",
            PostalCode = "12345",
            CountryCode = "A8"
        };

        [Test]
        public void GetGets()
        {
            Assert.AreEqual("ÃŽle-de-France", db.Get(8).Data.LocationName);
        }

        [Test]
        public void GetByAgencyGetsByAgency()
        {
            Assert.IsTrue(db.GetByAgency(8).Success);
        }

        [Test]
        public void InsertInserts()
        {
            Assert.AreEqual(place, db.Insert(place).Data);
        }

        [Test]
        public void UpdateUpdates()
        {
            Assert.IsTrue(db.Update(updatePlace).Success);
        }

        [Test]
        public void DeleteDeletes()
        {
            Assert.IsTrue(db.Delete(31).Success);
        }
    }
}
