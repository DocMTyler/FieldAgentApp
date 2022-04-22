using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;

namespace FieldAgent.DAL.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        public Response Delete(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<Agent> Get(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Mission>> GetMissions(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<Agent> Insert(Agent agent)
        {
            throw new NotImplementedException();
        }

        public Response Update(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}
