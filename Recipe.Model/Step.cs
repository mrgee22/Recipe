using Newtonsoft.Json;

namespace Recipe.Model
{
    public class Step
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "recipeId")]
        public int RecipeId { get; set; }
    }
}
