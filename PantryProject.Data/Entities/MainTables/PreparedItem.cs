using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
    public enum PreparedItemType { unclassified, puree, sauce, paste, blend, liquid, other }
    public enum PreparedItemState { liquid, solid, gas }
    public class PreparedItem
    {[Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public PreparedItemType TypeOfPreparedItem { get; set; }
        [Required]
        public PreparedItemState StateOfPreparedItem { get; set; }
        public virtual ICollection<Join_IngredientsInPreparedItem> Ingredients { get; set; }
        public virtual ICollection<Join_PreparedItemsInRecipe> RecipesWithPreparedItem { get; set; }
    }
}
