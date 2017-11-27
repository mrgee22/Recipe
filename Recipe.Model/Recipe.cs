using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recipe.Model
{
    public class Recipe
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = "steps")]
        public List<Step> Steps { get; set; }

        [JsonProperty(PropertyName = "createdById")]
        public string CreatedById { get; set; }
    }
}
