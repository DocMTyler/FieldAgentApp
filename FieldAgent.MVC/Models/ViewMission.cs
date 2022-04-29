using System;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.MVC.Models
{
    public class ViewMission
    {
        public int MissionID { get; set; }
        [Required(ErrorMessage = "Agency ID is required")]
        public int AgencyID { get; set; }
        [Required(ErrorMessage = "Code Name is required")]
        public string CodeName { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Project End Date is required")]
        public DateTime ProjectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal OperationalCost { get; set; }
    }
}
