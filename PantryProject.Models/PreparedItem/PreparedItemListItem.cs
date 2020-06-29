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
        public PreparedItemType TypeOfPreparedItem { get; set; }
        public PreparedItemState StateOfPreparedItem { get; set; }
    }
}
