using System;
using System.Threading.Tasks;
using HttpHelpers.ResponceServices;
using Newtonsoft.Json;
using PokemonViewer.ModelHelpers.HelperModels;

namespace PokemonViewer.ModelHelpers.HelperFunctions
{
    public class MapToObject
    {
        public static IHelperModel MapJsonToModel(Uri inputUri, IHelperModel inputModel)
        {
            var response = GetResponce.GetResponseString(inputUri);

            if (inputModel.GetType() == typeof(PokemonJson))
                inputModel = JsonConvert.DeserializeObject<PokemonJson>(response.Content.ReadAsStringAsync().Result);
            else if (inputModel.GetType() == typeof(AbilityJson))
                inputModel = JsonConvert.DeserializeObject<AbilityJson>(response.Content.ReadAsStringAsync().Result);
            else if (inputModel.GetType() == typeof(PokemonListJson))
                inputModel = JsonConvert.DeserializeObject<PokemonListJson>(response.Content.ReadAsStringAsync().Result);

            return inputModel;
        }
    }
}