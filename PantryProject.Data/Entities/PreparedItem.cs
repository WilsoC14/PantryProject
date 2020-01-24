using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
    public enum TypeOfPreparedItem { sauce, paste, blend, liquid, other }
    public enum StateOfPreparedItem { liquid, solid, gas }
    public class PreparedItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeOfPreparedItem PreparedItemType { get; set; }
        public StateOfPreparedItem PreparedItemState { get; set; }
        public virtual ICollection<IngredientInPreparedItem> Ingredients_In_PreparedItem { get; set; }
        public virtual ICollection<PreparedItemInRecipe> Recipes_With_PreparedItem { get; set; }
    }
}
