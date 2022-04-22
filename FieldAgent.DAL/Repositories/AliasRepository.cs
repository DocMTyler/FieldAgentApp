using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;

namespace FieldAgent.DAL.Repositories
{
    public class AliasRepository : IAliasRepository
    {
        public Response Delete(int aliasId)
        {
            throw new NotImplementedException();
        }

        public Response<Alias> Get(int aliasId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Alias>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<Alias> Insert(Alias alias)
        {
            throw new NotImplementedException();
        }

        public Response Update(Alias alias)
        {
            throw new NotImplementedException();
        }
    }
}
