using System;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.MVC.Models
{
    public class ViewAlias
    {
        
        public int AliasID { get; set; }
        public Guid InterpolID { get; set; }
        public string AliasName { get; set; }
        public string Persona { get; set; }
        
        [Required(ErrorMessage = "Agent Id is required")]
        public int AgentID { get; set; }
    }
}
