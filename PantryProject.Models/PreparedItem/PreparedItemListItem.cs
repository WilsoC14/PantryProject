using PantryProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.PreparedItem
{
    public class PreparedItemListItem
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public PreparedItemType TypeOf_PreparedItem { get; set; }
        public PreparedItemState StateOf_PreparedItem { get; set; }
    }
}
