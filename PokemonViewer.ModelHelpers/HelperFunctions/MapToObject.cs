using System;
using System.Threading.Tasks;
using HttpHelpers.ResponceServices;
using Newtonsoft.Json;
using PokemonViewer.ModelHelpers.HelperModels;

namespace PokemonViewer.ModelHelpers.HelperFunctions
{
    public class MapToObject
    {
        public static async Task<IHelperModel> MapJsonToModel(Uri inputUri, IHelperModel inputModel)
        {
            var response = await GetResponce.GetResponseString(inputUri);

            if (inputModel.GetType() == typeof(PokemonJson))
                inputModel = JsonConvert.DeserializeObject<PokemonJson>(await response.Content.ReadAsStringAsync());
            else if (inputModel.GetType() == typeof(AbilityJson))
                inputModel = JsonConvert.DeserializeObject<AbilityJson>(await response.Content.ReadAsStringAsync());
            else if (inputModel.GetType() == typeof(PokemonListJson))
                inputModel = JsonConvert.DeserializeObject<PokemonListJson>(await response.Content.ReadAsStringAsync());

            return inputModel;
        }
    }
}