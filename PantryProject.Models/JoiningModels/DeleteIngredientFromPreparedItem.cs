using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject.Models.JoiningModels
{
    public class DeleteIngredientFromPreparedItem
    {
        public int PreparedItemId { get; set; }
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }
        
    }
}
