//using PantryProject.Data;
using PantryProject.Data;
using PantryProject.Models.Ingredient;
using PantryProject.Models.PreparedItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.JoiningModels
{
    public class AddIngredientToPreparedItem
    {
        public PreparedItemDetail PreparedItemDetail {get; set;}
        public int IngredientID { get; set; }

        public string IngredientName { get; set; }
        [Required]
        public StateOfIngredient IngredientState { get; set; } // when adding an ingredient, you will need to declar what state the ingredient is in for this prepared item
        
        

        
    }
}
