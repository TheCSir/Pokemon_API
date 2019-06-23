using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonViewer.ModelHelpers.HelperModels
{
    public class PokemonListJson : IHelperModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}

