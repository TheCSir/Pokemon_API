using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonViewer.ModelHelpers.HelperModels
{
    public class PokemonJson : HelperModel
    {
        [JsonProperty("abilities")] public List<Ability> Abilities { get; set; }

        [JsonProperty("base_experience")] public int BaseExperience { get; set; }


        [JsonProperty("height")] public int Height { get; set; }


        [JsonProperty("id")] public int Id { get; set; }


        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("order")] public int Order { get; set; }

        [JsonProperty("sprites")] public Sprites Sprites { get; set; }

        [JsonProperty("stats")] public List<Stat> Stats { get; set; }

        [JsonProperty("types")] public List<TypeElement> Types { get; set; }

        [JsonProperty("weight")] public int Weight { get; set; }
    }

    public class Ability
    {
        [JsonProperty("ability")] public Species AbilityAbility { get; set; }

        [JsonProperty("is_hidden")] public bool IsHidden { get; set; }

        [JsonProperty("slot")] public int Slot { get; set; }
    }

    public class Species
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }
    }

    public class Sprites
    {
        [JsonProperty("back_default")] public Uri BackDefault { get; set; }

        [JsonProperty("back_female")] public Uri BackFemale { get; set; }

        [JsonProperty("back_shiny")] public Uri BackShiny { get; set; }

        [JsonProperty("back_shiny_female")] public Uri BackShinyFemale { get; set; }

        [JsonProperty("front_default")] public Uri FrontDefault { get; set; }

        [JsonProperty("front_female")] public Uri FrontFemale { get; set; }

        [JsonProperty("front_shiny")] public Uri FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")] public Uri FrontShinyFemale { get; set; }
    }

    public class Stat
    {
        [JsonProperty("base_stat")] public int BaseStat { get; set; }

        [JsonProperty("effort")] public int Effort { get; set; }

        [JsonProperty("stat")] public Species StatStat { get; set; }
    }

    public class TypeElement
    {
        [JsonProperty("slot")] public int Slot { get; set; }

        [JsonProperty("type")] public Species Type { get; set; }
    }
}