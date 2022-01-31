using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Domain.DTOs
{
    public class EventResumeDTO
    {
        public Guid EventId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
        public double TotalPaid { get; set; }
        public int TotalUsers { get; set; }
    }
}
