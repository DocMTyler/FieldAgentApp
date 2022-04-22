using System.Collections.Generic;

namespace FieldAgent.Core.Entities
{
    public class Agency
    {
        public int AgencyID { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }

        public List<AgencyAgent> AgencyAgents { get; set; }
        public List<Location> Locations { get; set; }
        public List<Mission> Missions { get; set; }
    }
}
