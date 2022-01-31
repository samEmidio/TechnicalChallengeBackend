using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Core.Entity;

namespace TechnicalChallenge.Domain.Entities
{
    public class EventUser : BaseEntity
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsPaid { get; set; }
    }
}
