﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Entities
{
    public class AgencyAgent
    {
        public int BadgeID { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime DeactivationDate { get; set; }
        public bool IsActive { get; set; }

        public int AgentID { get; set; }
        public Agent Agent { get; set; }
        
        public int AgencyID { get; set; }
        public Agency Agency { get; set; }

        public int SecurityClearanceID { get; set; }
        public SecurityClearance SecurityClearance { get; set; }

    }
}