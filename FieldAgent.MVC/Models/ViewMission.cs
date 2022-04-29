using System;
using System.ComponentModel.DataAnnotations;

namespace FieldAgent.MVC.Models
{
    public class ViewMission
    {
        public int MissionID { get; set; }
        public string CodeName { get; set; }
        public string Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ProjectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal OperationalCost { get; set; }
    }
}
