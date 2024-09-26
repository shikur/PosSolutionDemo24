using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pos.domain.model
{

   
       
        public class ColumnsOfAMenu
        {
            
            public int column_Id { get; set; }
            public string columnName { get; set; }
            public int menu_id { get; set; }
            public bool Isactive { get; set; }
        }
        // other properties
    

}
