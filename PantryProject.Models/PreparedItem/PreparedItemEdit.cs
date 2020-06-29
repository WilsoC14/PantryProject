using PantryProject.Data.Entities;
using PantryProject.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.PreparedItem
{
    public class PreparedItemEdit
    {
        public int Id { get; set; }
        public string OriginalName { get; set; }
        public string NewName { get; set; }

        public PreparedItemType TypeOfPreparedItem { get; set; }

        public PreparedItemState StateOfPreparedItem { get; set; }

        public List<IngredientListItem> ListOfIngredients { get; set; }
    }
}
