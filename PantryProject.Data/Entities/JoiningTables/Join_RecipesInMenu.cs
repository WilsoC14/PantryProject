﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Data.Entities
{
   public class Join_RecipesInMenu
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        [ForeignKey(nameof(Menu))]
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
