using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    public class Agent
    {
        private const string tableName = "MissionAgent";
        
        public int AgentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        //[Table(tableName)]

        public List<AgencyAgent> AgencyAgents { get; set; }
        public List<MissionAgent> MissionAgent { get; set; }
        public List<Alias> Aliases { get; set; }
    }
}
