using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Entities
{
    public class MissionAgent
    {
        public int MissionID { get; set; }
        public Mission Mission { get; set; }

        public int AgentID { get; set; }
        public Agent Agent { get; set; }
    }
}
