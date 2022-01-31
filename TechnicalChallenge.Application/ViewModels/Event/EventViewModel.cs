using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Application.ViewModels.Event
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
