using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Core.Entity;

namespace TechnicalChallenge.Domain.Entities
{
    public class Event : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? AdditionalInformation { get; set; }
        public List<EventUser> EventUsers { get; set; } = new List<EventUser>();
    }
}
