﻿using PantryProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data
{
    public enum IngredientType {
        Unclassified, Fruit, Vegetable, Starch, Meat, Fish, Other }
    public enum StateOfIngredient {Unclassified, Solid, Liquid, Gas, Granule, Powder, Other }

    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
       
        public IngredientType TypeOfIngredient { get; set; }
        public StateOfIngredient IngredientState { get; set; }      // I don't feel like state is important upon create, maybe something we can change dependent upon an ingredients use... don't necessarily want to have separate ingredients for granulated garlic and garlic powder... or maybe we do, but am going to table that for now
        public virtual ICollection<Join_IngredientsInPreparedItem> PreparedItemsWithIngredient { get; set; }
        public virtual ICollection<Join_IngredientsInRecipe> RecipesWithIngredient { get; set; }
    }
}
