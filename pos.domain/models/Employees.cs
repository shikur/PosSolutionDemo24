using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Models
{
   public class Employees
    {
        public int Emp_ID { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Pay_Type { get; set; }
        public string Password { get; set; }
        public int Store_ID { get; set; }
        public DateTime Date_Start { get; set; }
        public DateTime Date_END { get; set; }
        public decimal Pay_Amount { get; set; }
        public string Email { get; set; }
    }
}
