using PantryProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data
{  public enum TypeOfIngredient { Fruit, Vegetable, Starch, Meat, Fish, Other}
    public enum StateOfIngredient { Solid, Liquid, Gas, Granule, Powder, Other}
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeOfIngredient IngredientType { get; set; }
        public StateOfIngredient IngredientState { get; set; }
        public virtual ICollection<IngredientInPreparedItem> PreparedItems_With_Ingredient { get; set; }
        public virtual ICollection<IngredientInRecipe> Recipes_With_Ingredient { get; set; }
    }
}
