﻿namespace FieldAgent.Core.Entities
{
    public class Alias
    {
        public int AliasID { get; set; }
        public int InterpolID { get; set; }
        public string AliasName { get; set; }
        public string Persona { get; set; }

        public int AgentID { get; set; }
        public Agent Agent { get; set; }
    }
}
