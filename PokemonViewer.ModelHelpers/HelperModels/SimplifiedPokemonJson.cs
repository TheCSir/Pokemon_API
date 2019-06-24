using Newtonsoft.Json;

namespace PokemonViewer.ModelHelpers.HelperModels
{
    public class SimplifiedPokemonJson : HelperModel
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("order")] public int Order { get; set; }


        [JsonProperty("sprites")] public Sprites Sprites { get; set; }
    }
}