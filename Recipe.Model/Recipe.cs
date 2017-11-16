using System.Collections.Generic;

namespace Recipe.Model
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public List<Step> Steps { get; set; }
        public int CreatedBy { get; set; }
    }
}
