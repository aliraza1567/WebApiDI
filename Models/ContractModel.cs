using System;

namespace DutchCourse.WebApi.Models
{
    public class ContractModel
    {
        public decimal TotalHours { get; set; }
        public decimal LesMaterialCost { get; set; }
        public decimal AdminCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerHour { get; set; }
        public DateTime ContractDate { get; set; }
    }
}
