using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Domain.DTOs
{
    public class EventResumeDetailDTO
    {
        public double TotalToPay { get; set; }
        public double TotalPaid { get; set; }
        public int TotalUsers { get; set; }
        public int TotalPaidUsers { get; set; }
    }
}
