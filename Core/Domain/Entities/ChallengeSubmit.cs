using Domain.Entities.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChallengeSubmit : BaseEntity
    {
        public Guid ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string SubmitValue { get; set; }

        public bool IsSuccess { get; set; }
    }
}
