using AcmeCorp.ContactInfo.Entities.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Entities.DBO
{
    public class ContactDBO : ContactBO
    {
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<OrderDBO> Orders { get; set; }
    }
}
