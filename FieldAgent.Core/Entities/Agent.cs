﻿using System;
using System.Collections.Generic;

namespace FieldAgent.Core.Entities
{
    public class Agent
    {
        public int AgentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }

        List<AgencyAgent> AgencyAgents { get; set; }
        List<MissionAgent> MissionAgents { get; set; }
        List<Alias> Aliases { get; set; }
    }
}
