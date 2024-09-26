using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pos.domain.model
{
    public class Customer
    {
        public int? Cust_ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateLastTrans { get; set; } = DateTime.Now;

    }
}



 
