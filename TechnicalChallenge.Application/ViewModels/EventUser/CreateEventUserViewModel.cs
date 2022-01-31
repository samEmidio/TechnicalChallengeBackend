using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Application.ViewModels.EventUser
{
    public class CreateEventUserViewModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsPaid { get; set; }
    }
}

