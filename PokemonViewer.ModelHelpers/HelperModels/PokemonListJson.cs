using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonViewer.ModelHelpers.HelperModels
{
    public class PokemonListJson : HelperModel
    {
        [JsonProperty("count")] public int Count { get; set; }

        [JsonProperty("next")] public Uri Next { get; set; }

        [JsonProperty("previous")] public object Previous { get; set; }

        [JsonProperty("results")] public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("url")] public Uri Url { get; set; }
    }
}