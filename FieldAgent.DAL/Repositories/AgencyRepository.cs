using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldAgent.DAL.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private DBFactory DbFac;

        public AgencyRepository(DBFactory dbFac)
        {
            DbFac = dbFac;
        }

        public Response Delete(int agencyId)
        {
            Response response = new();
            using(var db = DbFac.GetDbContext())
            {
                var agency = db.Agency.Single(a => a.AgencyID == agencyId);
                if(agency != null)
                {
                    db.Agency.Remove(agency);
                    db.SaveChanges();
                    response.Message = "Deleted";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Not deleted";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<Agency> Get(int agencyId)
        {
            Response<Agency> response = new Response<Agency>();
            using(var db = DbFac.GetDbContext())
            {
                response.Data = db.Agency.Find(agencyId);
                if(response.Data != null)
                {
                    response.Message = "Got";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Not Got";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<List<Agency>> GetAll()
        {
            Response<List<Agency>> response = new Response<List<Agency>>();
            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Agency.ToList();
                if (response.Data != null)
                {
                    response.Message = "Got";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Not Got";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<Agency> Insert(Agency agency)
        {
            Response<Agency> response = new Response<Agency>();
            using(var db = DbFac.GetDbContext())
            {
                if(agency != null)
                {
                    db.Agency.Add(agency);
                    db.SaveChanges();
                    response.Data = agency;
                    response.Message = "Added";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Not added";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response Update(Agency agency)
        {
            Response response = new();
            using(var db = DbFac.GetDbContext())
            {
                var foundAgency = db.Agency.Find(agency.AgencyID);
                if(foundAgency != null)
                {
                    foundAgency.ShortName = agency.ShortName;
                    foundAgency.LongName = agency.LongName;
                    db.Agency.Update(foundAgency);
                    db.SaveChanges();
                    response.Message = "Updated";
                    response.Success = true;
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
