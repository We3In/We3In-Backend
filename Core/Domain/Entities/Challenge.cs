using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Challenge : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public long Price { get; set; }
        
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
