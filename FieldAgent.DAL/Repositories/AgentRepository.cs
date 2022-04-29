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
        /*private DBFactory DbFac;

        public AgentRepository(DBFactory dbFac)
        {
            DbFac = dbFac;
        }
*/
        public Response Delete(int agentId)
        {
            Response response = new();
            using (var db = new AppDbContext())
            {
                var agent = db.Agent.Single(a => a.AgentID == agentId);
                if (agent != null)
                {
                    try
                    {
                        var agencyAgents = db.AgencyAgent.Where(aa => aa.AgentID == agentId);
                        foreach(var aa in agencyAgents)
                        {
                            db.AgencyAgent.Remove(aa);
                        }

                        var aliases = db.Alias.Where(al => al.AgentID == agentId);
                        foreach(var al in aliases)
                        {
                            db.Alias.Remove(al);
                        }

                        var missionAgents = db.MissionAgent.Where(ma => ma.AgentId == agentId);
                        foreach(var ma in missionAgents)
                        {
                            db.MissionAgent.Remove(ma);
                        }
                        
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
            using (var db = new AppDbContext())
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
            Response<List<Mission>> response = new Response<List<Mission>>();
            using(var db = new AppDbContext())
            {
                var mission = db.Mission
                     .Include(m => m.MissionAgent)
                     .ToList();

                if (mission != null)
                {
                    response.Data = mission
                        .Where(m => m.MissionAgent
                        .Any(ma => ma.AgentId == agentId))
                        .ToList();
                    response.Success = true;
                    response.Message = "Got";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Not got";
                }
            }
            return response;
        }

        public Response<Agent> Insert(Agent agent)
        {
            Response<Agent> response = new Response<Agent>();
            using (var db = new AppDbContext())
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
            using (var db = new AppDbContext())
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
