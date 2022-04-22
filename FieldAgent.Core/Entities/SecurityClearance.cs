﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Entities
{
    public class SecurityClearance
    {
        public int SecurityClearanceID { get; set; }
        public string SecurityClearanceName { get; set; }

        List<AgencyAgent> AgencyAgents { get; set; }
    }
}