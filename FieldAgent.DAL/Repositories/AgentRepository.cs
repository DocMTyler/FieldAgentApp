using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldAgent.DAL.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private DBFactory DbFac;

        public AgentRepository(DBFactory dbFac)
        {
            DbFac = dbFac;
        }

        public Response Delete(int agentId)
        {
            Response response = new();
            using (var db = DbFac.GetDbContext())
            {
                var agent = db.Agent.Single(a => a.AgentID == agentId);
                if (agent != null)
                {
                    try
                    {
                        db.Agent.Remove(agent);
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

        public Response<Agent> Get(int agentId)
        {
            Response<Agent> response = new Response<Agent>();
            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Agent.Find(agentId);
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

        public Response<List<Mission>> GetMissions(int agentId)
        {
            Response<List<Mission>> missions = new Response<List<Mission>>();
            using(var db = DbFac.GetDbContext())
            {
                   
            }
            return missions;
        }

        public Response<Agent> Insert(Agent agent)
        {
            Response<Agent> response = new Response<Agent>();
            using (var db = DbFac.GetDbContext())
            {
                if (agent != null)
                {
                    try
                    {
                        db.Agent.Add(agent);
                        db.SaveChanges();
                        response.Data = agent;
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

        public Response Update(Agent agent)
        {
            Response response = new();
            using (var db = DbFac.GetDbContext())
            {
                var foundAgent = db.Agent.Find(agent.AgentID);
                if (foundAgent != null)
                {
                    try
                    {
                        foundAgent.FirstName = agent.FirstName;
                        foundAgent.LastName = agent.LastName;
                        foundAgent.DateOfBirth = agent.DateOfBirth;
                        foundAgent.Height = agent.Height;
                        db.Agent.Update(foundAgent);
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
