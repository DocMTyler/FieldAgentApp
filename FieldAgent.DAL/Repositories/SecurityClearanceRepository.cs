using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FieldAgent.DAL.Repositories
{
    public class SecurityClearanceRepository : ISecurityClearanceRepository
    {
        DBFactory DbFac;

        public SecurityClearanceRepository(DBFactory dbFac)
        {
            DbFac = dbFac;
        }
        
        public Response<SecurityClearance> Get(int securityClearanceId)
        {
            Response<SecurityClearance> response = new Response<SecurityClearance>();
            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.SecurityClearance
                    .Single(aa => aa.SecurityClearanceID == securityClearanceId);
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

        public Response<List<SecurityClearance>> GetAll()
        {
            Response<List<SecurityClearance>> response = new Response<List<SecurityClearance>>();
            using (var db = DbFac.GetDbContext())
            {
                response.Data = db.SecurityClearance.ToList();
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
    }
}
