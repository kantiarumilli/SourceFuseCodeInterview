using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Entities.BO
{
    public class OrderBO
    {
        public string Id { get; set; }
        public DateTime OrderPlacedAt { get; set; }
        public int Status { get; set; }
        public string CustomerId { get; set; }
    }
}
