using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Entities.BO
{
    public class ContactBO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public int Country { get; set; }
    }
}
