using PantryProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.PreparedItem
{
    public class PreparedItem_Create
    {
        public string Name { get; set; }
        public PreparedItem_Type PreparedItemType { get; set; }
        public PreparedItem_State PreparedItemState { get; set; }
        // should a list of ingredients be added to this now, or do we funnel into that through the UI?
    }
}
