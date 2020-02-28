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
        public PreparedItem_Type TypeOf_PreparedItem { get; set; }
        public PreparedItem_State StateOf_PreparedItem { get; set; }
        // should a list of ingredients be added to this now, or do we funnel into that through the UI?
    }
}
