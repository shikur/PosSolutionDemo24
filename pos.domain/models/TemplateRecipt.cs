using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Models
{
    class TemplateRecipt
    {
        public int TempRec_ID { get; set; }
        public decimal Width { get; set; }
        public string header { get; set; }
        public string footer { get; set; }
        public string Body { get; set; }
        public string headerPos { get; set; }
        public string backgroundColor { get; set; }
        public string footerPos { get; set; }
    }
}
