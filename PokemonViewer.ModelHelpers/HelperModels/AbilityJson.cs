using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonViewer.ModelHelpers.HelperModels
{
    public partial class AbilityJson : IHelperModel
    {
        [JsonProperty("effect_changes")]
        public List<object> EffectChanges { get; set; }

        [JsonProperty("effect_entries")]
        public List<EffectEntry> EffectEntries { get; set; }


        [JsonProperty("generation")]
        public Generation Generation { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
    }

    public partial class EffectEntry
    {
        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("language")]
        public Generation Language { get; set; }

        [JsonProperty("short_effect")]
        public string ShortEffect { get; set; }
    }

    public partial class Generation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}

