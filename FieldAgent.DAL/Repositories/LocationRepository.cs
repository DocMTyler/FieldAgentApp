using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldAgent.DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        DBFactory DbFac;

        public LocationRepository(DBFactory dbFac)
        {
            DbFac = dbFac;
        }

        public Response Delete(int locationId)
        {
            Response response = new Response();
            using(var db = DbFac.GetDbContext())
            {
                var location = db.Location
                    .Single(l => l.LocationID == locationId);
                if(location != null)
                {
                    try
                    {
                        db.Location.Remove(location);
                        db.SaveChanges();
                        response.Message = "Deleted";
                        response.Success = true;
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); } 
                }
                else
                {
                    response.Message = "Not deleted";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<Location> Get(int locationId)
        {
            Response<Location> response = new Response<Location>();
            using(var db = DbFac.GetDbContext())
            {
                response.Data = db.Location
                    .Single(l => l.LocationID == locationId);
                if(response.Data != null)
                {
                    response.Message = "Got";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Not got";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<List<Location>> GetByAgency(int agencyId)
        {
            Response<List<Location>> response = new Response<List<Location>>();
            using(var db = DbFac.GetDbContext())
            {
                response.Data = db.Location.Where(a => a.AgencyID == agencyId).ToList();
                if(response.Data != null)
                {
                    response.Message = "Got by agency";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Not got";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<Location> Insert(Location location)
        {
            Response<Location> response = new Response<Location>();
            using(var db = DbFac.GetDbContext())
            {
                if(location != null)
                {
                    try
                    {
                        db.Location.Add(location);
                        db.SaveChanges();
                        response.Data = location;
                        response.Message = "Added";
                        response.Success = true;
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); } 
                }
                else
                {
                    response.Message = "Not added";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response Update(Location location)
        {
            Response response = new();
            using(var db = DbFac.GetDbContext())
            {
                var foundLocation = db.Location.Single(l => l.LocationID == location.LocationID);
                if(foundLocation != null)
                {
                    try
                    {
                        foundLocation.LocationName = location.LocationName;
                        foundLocation.Street1 = location.Street1;
                        foundLocation.Street2 = location.Street2;
                        foundLocation.City = location.City;
                        foundLocation.PostalCode = location.PostalCode;
                        foundLocation.CountryCode = location.CountryCode;
                        db.Location.Update(foundLocation);
                        db.SaveChanges();
                        response.Message = "Updated";
                        response.Success = true;
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); } 
                }
                else
                {
                    response.Message = "Not updated";
                    response.Success = false;
                }
            }
            return response;
        }
    }
}
