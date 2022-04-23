using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldAgent.DAL.Repositories
{
    public class AliasRepository : IAliasRepository
    {
        private DBFactory DbFac;

        public AliasRepository(DBFactory dbFac)
        {
            DbFac = dbFac;
        }

        public Response Delete(int aliasId)
        {
            Response response = new();
            using (var db = DbFac.GetDbContext())
            {
                var alias = db.Alias.Single(a => a.AliasID == aliasId);
                if (alias != null)
                {
                    db.Alias.Remove(alias);
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

        public Response<Alias> Get(int aliasId)
        {
            Response<Alias> response = new Response<Alias>();
            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.Alias.Find(aliasId);
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

        public Response<List<Alias>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<Alias> Insert(Alias alias)
        {
            Response<Alias> response = new Response<Alias>();
            using (var db = DbFac.GetDbContext())
            {
                try
                {
                    if (alias != null)
                    {
                        db.Alias.Add(alias);
                        db.SaveChanges();
                        response.Data = alias;
                        response.Message = "Added";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Not added";
                        response.Success = false;
                    }
                }catch(Exception e)
                {
                    Console.WriteLine("e.Message");
                }
                
            }
            return response;
        }

        public Response Update(Alias alias)
        {
            Response response = new();
            using (var db = DbFac.GetDbContext())
            {
                var foundAlias = db.Alias.Find(alias.AliasID);
                if (foundAlias != null)
                {
                    foundAlias.AliasName = alias.AliasName;
                    foundAlias.Persona = alias.Persona;
                    db.Alias.Update(foundAlias);
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
