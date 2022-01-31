using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Domain.Core.Entity
{
    public class AuditEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
