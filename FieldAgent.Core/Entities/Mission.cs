using System;
using System.Collections.Generic;

namespace FieldAgent.Core.Entities
{
    public class Mission
    {
        public int MissionID { get; set; }
        public string CodeName { get; set; }
        public string Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ProjectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal OperationalCost { get; set; }

        public int AgencyID { get; set; }
        public Agency Agency { get; set; }

        public List<MissionAgent> MissionAgent { get; set; }
    }
}
