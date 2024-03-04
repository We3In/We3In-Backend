using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Event.GetEventProduct
{
    public class GetAllProductQueryResponse
    {
        public int TotalCount { get; set; }
        public object Events { get; set; }
    }
}
