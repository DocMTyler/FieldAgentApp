using FieldAgent.Core;
using FieldAgent.Core.DTOs;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;

namespace FieldAgent.DAL.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        public Response<List<ClearanceAuditListItem>> AuditClearance(int securityClearanceId, int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<List<PensionListItem>> GetPensionList(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<List<TopAgentListItem>> GetTopAgents()
        {
            throw new NotImplementedException();
        }
    }
}
