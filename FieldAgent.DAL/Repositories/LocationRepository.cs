using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;

namespace FieldAgent.DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public Response Delete(int locationId)
        {
            throw new NotImplementedException();
        }

        public Response<Location> Get(int locationId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Location>> GetByAgency(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<Location> Insert(Location location)
        {
            throw new NotImplementedException();
        }

        public Response Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
