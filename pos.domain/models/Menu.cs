using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Models
{
    public class Menu
    {
        public int Menu_Id { get; set; }
        public string MenuType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Isactive { get; set; }

        public ICollection<ColumnsOfAMenu> ListOfColumns { get; set; }
    }

    public class ColumnsOfAMenu
    {
        public int column_Id { get; set; }
        public string columnName { get; set; }
        public int menu_id { get; set; }
        public bool Isactive { get; set; }
    }
}
