using System;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.MVC.Models
{
    public class ViewAgencyAgent
    {
        public int AgencyID { get; set; }

        public int AgentID { get; set; }

        public int SecurityClearanceID { get; set; }

        [Required(ErrorMessage = "Badge ID is required")]
        public Guid BadgeID { get; set; }
        
        [Required(ErrorMessage = "Activation Date is required")]
        public DateTime ActivationDate { get; set; }
        
        public DateTime DeactivationDate { get; set; }
        
        [Required(ErrorMessage = "Must have a value for IsActive")]
        public bool IsActive { get; set; }
    }
}
