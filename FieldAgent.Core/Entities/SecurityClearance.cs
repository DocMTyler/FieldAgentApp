using System.Collections.Generic;

namespace FieldAgent.Core.Entities
{
    public class SecurityClearance
    {
        public int SecurityClearanceID { get; set; }
        public string SecurityClearanceName { get; set; }

        List<AgencyAgent> AgencyAgents { get; set; }
    }
}
