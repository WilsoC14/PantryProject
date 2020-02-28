using PantryProject.Data.Entities;
using PantryProject.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.PreparedItem
{
    public class PreparedItem_Edit
    {
        public int Id { get; set; }
        public string OriginalName { get; set; }
        public string NewName { get; set; }

        public PreparedItem_Type TypeOf_PreparedItem { get; set; }

        public PreparedItem_State StateOf_PreparedItem { get; set; }

        public List<Ingredient_ListItem> ListOfIngredients { get; set; }
    }
}
