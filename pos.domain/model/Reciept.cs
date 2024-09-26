using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.domain.model
{
    public class Reciept
    {
        public int Rec_ID { get; set; }
        public int Batch_ID { get; set; }
        public DateTime Datetime { get; set; }
        public int Template_ID { get; set; }
    }
}
