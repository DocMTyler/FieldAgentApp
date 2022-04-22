using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;

namespace FieldAgent.DAL.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        public Response Delete(int missionId)
        {
            throw new NotImplementedException();
        }

        public Response<Mission> Get(int missionId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Mission>> GetByAgency(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Mission>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
        }

        public Response<Mission> Insert(Mission mission)
        {
            throw new NotImplementedException();
        }

        public Response Update(Mission mission)
        {
            throw new NotImplementedException();
        }
    }
}
