using PantryProject.Data.Entities;
using PantryProject.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.PreparedItem
{
    public class PreparedItemDetail
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public PreparedItemType TypeOf_PreparedItem { get; set; }
        
        public PreparedItemState StateOf_PreparedItem { get; set; }

        public List<IngredientListItem> ListOfIngredients { get; set; }

        
    }
}
