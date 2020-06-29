using PantryProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.PreparedItem
{
    public class PreparedItemCreate
    {
        public string Name { get; set; }
        public PreparedItemType TypeOfPreparedItem { get; set; }
        public PreparedItemState StateOfPreparedItem { get; set; }
        // should a list of ingredients be added to this now, or do we funnel into that through the UI?
    }
}
