using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonViewer.ModelHelpers.HelperModels
{
    public partial class AbilityJson : HelperModel
    {

        [JsonProperty("effect_entries")] public List<EffectEntry> EffectEntries { get; set; }


        [JsonProperty("id")] public long Id { get; set; }


        [JsonProperty("name")] public string Name { get; set; }

    }

    public partial class EffectEntry
    {
        [JsonProperty("effect")] public string Effect { get; set; }


        [JsonProperty("short_effect")] public string ShortEffect { get; set; }
    }
}

