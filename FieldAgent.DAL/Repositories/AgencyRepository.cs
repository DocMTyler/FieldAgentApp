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
                    try
                    {
                        var agencyAgents = db.AgencyAgent
                            .Where(aa => aa.AgencyID == agencyId);
                        foreach(var aa in agencyAgents)
                        {
                            db.AgencyAgent.Remove(aa);
                        }

                        var locations = db.Location
                            .Where(l => l.AgencyID == agencyId);
                        foreach(var l in locations)
                        {
                            db.Location.Remove(l);
                        }
                        
                        List<Mission> missions = db.Mission
                            .Where(m => m.AgencyID == agencyId).ToList();
                        foreach(var mission in missions)
                        {
                            List<MissionAgent> missionAgents = db.MissionAgent.Where(ma => ma.MissionId == mission.MissionID).ToList();
                            foreach(var missionAgent in missionAgents)
                            {
                                db.MissionAgent.Remove(missionAgent);
                            }
                        }

                        foreach(var mission in missions)
                        {
                            db.Mission.Remove(mission);
                        }

                        db.Agency.Remove(agency);
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
                    try
                    {
                        db.Agency.Add(agency);
                        db.SaveChanges();
                        response.Data = agency;
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

        public Response Update(Agency agency)
        {
            Response response = new();
            using(var db = DbFac.GetDbContext())
            {
                var foundAgency = db.Agency.Find(agency.AgencyID);
                if(foundAgency != null)
                {
                    try
                    {
                        foundAgency.ShortName = agency.ShortName;
                        foundAgency.LongName = agency.LongName;
                        db.Agency.Update(foundAgency);
                        db.SaveChanges();
                        response.Message = "Updated";
                        response.Success = true;
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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
