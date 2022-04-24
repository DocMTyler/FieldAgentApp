using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldAgent.DAL
{
    public class AgencyAgentRepository : IAgencyAgentRepository
    {
        DBFactory DbFac;

        public AgencyAgentRepository(DBFactory dbFac) 
        {
            DbFac = dbFac;
        }
        
        public Response Delete(int agencyid, int agentid)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();
            using (var db = DbFac.GetDbContext())
            {
                var agencyAgent = db.AgencyAgent
                    .Single(aa => aa.AgencyID == agencyid && aa.AgentID == agentid);
                if (agencyAgent != null)
                {
                    db.AgencyAgent.Remove(agencyAgent);
                    db.SaveChanges();
                    response.Message = "Got";
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

        public Response<AgencyAgent> Get(int agencyid, int agentid)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();
            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.AgencyAgent
                    .Single(aa => aa.AgencyID == agencyid && aa.AgentID == agentid);
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

        public Response<List<AgencyAgent>> GetByAgency(int agencyId)
        {
            Response<List<AgencyAgent>> response = new Response<List<AgencyAgent>>();
            using(var db = DbFac.GetDbContext())
            {
                response.Data = db.AgencyAgent.Where(a => a.AgencyID == agencyId).ToList();
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

        public Response<List<AgencyAgent>> GetByAgent(int agentId)
        {
            Response<List<AgencyAgent>> response = new Response<List<AgencyAgent>>();
            using(var db = DbFac.GetDbContext())
            {
                response.Data = db.AgencyAgent.Where(a => a.AgentID == agentId).ToList();
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

        public Response<AgencyAgent> Insert(AgencyAgent agencyAgent)
        {
            Response<AgencyAgent> response = new Response<AgencyAgent>();
            using (var db = DbFac.GetDbContext())
            {
                try
                {
                    if (agencyAgent != null)
                    {
                        db.AgencyAgent.Add(agencyAgent);
                        db.SaveChanges();
                        response.Data = agencyAgent;
                        response.Message = "Added";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Not added";
                        response.Success = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("e.Message");
                }

            }
            return response;
        }

        public Response Update(AgencyAgent agencyAgent)
        {
            Response response = new();
            using (var db = DbFac.GetDbContext())
            {
                var foundAgencyAgent = db.AgencyAgent.Single(aa => aa.BadgeID == agencyAgent.BadgeID);
                if (foundAgencyAgent != null)
                {
                    foundAgencyAgent.ActivationDate = agencyAgent.ActivationDate;
                    foundAgencyAgent.DeactivationDate = agencyAgent.DeactivationDate;
                    db.AgencyAgent.Update(foundAgencyAgent);
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
