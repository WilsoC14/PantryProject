using PantryProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.Ingredient
{
    public class IngredientEdit
    {
        public int Id { get; set; }

        public string OriginalName { get; set; }
        public string NewName { get; set; }

        public IngredientType TypeOfIngredient { get; set; }
        public StateOfIngredient IngredientState { get; set; }

    }
}
