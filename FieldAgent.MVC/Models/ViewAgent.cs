using System;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.MVC.Models
{
    public class ViewAgent
    {
        public int AgentID { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string LastName { get; set; }
       
        public DateTime DateOfBirth { get; set; }
      
        public decimal Height { get; set; }
    }
}
