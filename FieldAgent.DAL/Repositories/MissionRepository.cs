﻿using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldAgent.DAL.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        DBFactory DbFac;

        public MissionRepository(DBFactory dbFac)
        {
            DbFac = dbFac;
        }
        
        public Response Delete(int missionId)
        {
            Response response = new Response();
            using (var db = DbFac.GetDbContext())
            {
                var mission = db.Mission
                    .Single(aa => aa.MissionID == missionId);
                if (mission != null)
                {
                    db.Mission.Remove(mission);
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

        public Response<Mission> Get(int missionId)
        {
            Response<Mission> response = new Response<Mission>();
            using(var db = DbFac.GetDbContext())
            {
                response.Data = db.Mission
                    .Single(l => l.MissionID == missionId);
                if(response != null)
                {
                    response.Message = "Fuck ou===";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fuck you";
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<List<Mission>> GetByAgency(int agencyId)
        {
            Response<List<Mission>> response = new Response<List<Mission>>();
            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Mission.Where(a => a.AgencyID == agencyId).ToList();
                if (response.Data != null)
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

        public Response<List<Mission>> GetByAgent(int agentId)
        {
            Response<List<Mission>> response = new Response<List<Mission>>();
            /*using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Mission.Where(a => a.AgentID == agentId).ToList();
                if (response.Data != null)
                {
                    response.Message = "Got";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Not got";
                    response.Success = false;
                }
            }*/
            return response;
        }

        public Response<Mission> Insert(Mission mission)
        {
            Response<Mission> response = new Response<Mission>();
            using (var db = DbFac.GetDbContext())
            {
                try
                {
                    if (mission != null)
                    {
                        db.Mission.Add(mission);
                        db.SaveChanges();
                        response.Data = mission;
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

        public Response Update(Mission mission)
        {
            Response response = new();
            using (var db = DbFac.GetDbContext())
            {
                var foundMission = db.Mission.Single(aa => aa.MissionID == mission.MissionID);
                if (foundMission != null)
                {
                    foundMission.CodeName = mission.CodeName;
                    foundMission.StartDate = mission.StartDate;
                    foundMission.ProjectedEndDate = mission.ProjectedEndDate;
                    foundMission.ActualEndDate = mission.ActualEndDate;
                    foundMission.OperationalCost = mission.OperationalCost;
                    foundMission.Notes = mission.Notes;
                    db.Mission.Update(foundMission);
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
