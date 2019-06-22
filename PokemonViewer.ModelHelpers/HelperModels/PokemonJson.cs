using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonViewer.ModelHelpers.HelperModels
{
    public partial class PokemonJson : IHelperModel
    {
        [JsonProperty("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("forms")]
        public List<Species> Forms { get; set; }

        [JsonProperty("game_indices")]
        public List<GameIndex> GameIndices { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("held_items")]
        public List<object> HeldItems { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public Uri LocationAreaEncounters { get; set; }

        [JsonProperty("moves")]
        public List<Move> Moves { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("stats")]
        public List<Stat> Stats { get; set; }

        [JsonProperty("types")]
        public List<TypeElement> Types { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }

    public partial class Ability
    {
        [JsonProperty("ability")]
        public Species AbilityAbility { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }

    public partial class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class GameIndex
    {
        [JsonProperty("game_index")]
        public int GameIndexGameIndex { get; set; }

        [JsonProperty("version")]
        public Species Version { get; set; }
    }

    public partial class Move
    {
        [JsonProperty("move")]
        public Species MoveMove { get; set; }

        [JsonProperty("version_group_details")]
        public List<VersionGroupDetail> VersionGroupDetails { get; set; }
    }

    public partial class VersionGroupDetail
    {
        [JsonProperty("level_learned_at")]
        public int LevelLearnedAt { get; set; }

        [JsonProperty("move_learn_method")]
        public Species MoveLearnMethod { get; set; }

        [JsonProperty("version_group")]
        public Species VersionGroup { get; set; }
    }

    public partial class Sprites
    {
        [JsonProperty("back_default")]
        public Uri BackDefault { get; set; }

        [JsonProperty("back_female")]
        public Uri BackFemale { get; set; }

        [JsonProperty("back_shiny")]
        public Uri BackShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public Uri BackShinyFemale { get; set; }

        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public Uri FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public Uri FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public Uri FrontShinyFemale { get; set; }
    }

    public partial class Stat
    {
        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }

        [JsonProperty("effort")]
        public int Effort { get; set; }

        [JsonProperty("stat")]
        public Species StatStat { get; set; }
    }

    public partial class TypeElement
    {
        [JsonProperty("slot")]
        public int Slot { get; set; }

        [JsonProperty("type")]
        public Species Type { get; set; }
    }
}
