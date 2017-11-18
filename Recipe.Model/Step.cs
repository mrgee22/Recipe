using Newtonsoft.Json;

namespace Recipe.Model
{
    public class Step
    {
        [JsonProperty(PropertyName = "stepId")]
        public int StepId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "recipeId")]
        public int RecipeId { get; set; }
    }
}
