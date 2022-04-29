using System;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.MVC.Models
{
    public class ViewAgency
    {
        public int AgencyID { get; set; }
        
        [Required(ErrorMessage ="Name is required")]
        [StringLength(25, ErrorMessage = "Name cannot exceed 25 characters")]
        public string ShortName { get; set; }
        
        public string LongName { get; set; }
    }
}
