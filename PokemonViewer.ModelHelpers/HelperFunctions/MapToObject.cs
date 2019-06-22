using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonViewer.ModelHelpers.HelperModels;
using HttpHelpers.ResponceServices;

namespace PokemonViewer.ModelHelpers.HelperFunctions
{
    public class MapToObject
    {
        public static async Task<IHelperModel> MapJsonToModel(Uri inputUri)
        {
            var response = await GetResponce.GetResponseString(inputUri);
            IHelperModel inputModel  = JsonConvert.DeserializeObject<PokemonJson>(await response.Content.ReadAsStringAsync());

            return inputModel;
        }
    }
}
