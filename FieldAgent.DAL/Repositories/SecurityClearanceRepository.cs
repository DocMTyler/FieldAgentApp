using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;

namespace FieldAgent.DAL.Repositories
{
    public class SecurityClearanceRepository : ISecurityClearanceRepository
    {
        public Response<SecurityClearance> Get(int securityClearanceId)
        {
            throw new NotImplementedException();
        }

        public Response<List<SecurityClearance>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
