using System;
using HttpHelpers.ResponseServices;
using Newtonsoft.Json;
using PokemonViewer.ModelHelpers.HelperModels;

namespace PokemonViewer.ModelHelpers.HelperFunctions
{
    /// <summary>
    ///     This class contain methods to map an input  to a Helper model
    /// </summary>
    public class MapToObject
    {
        /// <summary>
        ///     This function will crete and return a helper model according to inputs
        /// </summary>
        /// <param name="inputUri"> url fpr Api endpoint </param>
        /// <param name="inputModel"> Helper model object </param>
        /// <returns>
        ///     generated Helper model / null if creation fails
        /// </returns>
        public static HelperModel MapJsonToModel(Uri inputUri, HelperModel inputModel)
        {
            // get response form HttpHelper class library helper functions
            // will return null if unsuccessful.
            var response = GetResponse.GetResponseString(inputUri);

            // loop through all helper model types and deserialize and create matching helper model
            try
            {
                // if type of Pokemon
                if (inputModel.GetType() == typeof(PokemonJson))
                    inputModel =
                        JsonConvert.DeserializeObject<PokemonJson>(response.Content.ReadAsStringAsync().Result);

                // if type of Ability
                else if (inputModel.GetType() == typeof(AbilityJson))
                    inputModel =
                        JsonConvert.DeserializeObject<AbilityJson>(response.Content.ReadAsStringAsync().Result);

                // if type of List of pokemon
                else if (inputModel.GetType() == typeof(PokemonListJson))
                    inputModel =
                        JsonConvert.DeserializeObject<PokemonListJson>(response.Content.ReadAsStringAsync().Result);

                // if type of Simplified Pokemon
                else if (inputModel.GetType() == typeof(SimplifiedPokemonJson))
                    inputModel =
                        JsonConvert.DeserializeObject<SimplifiedPokemonJson>(
                            response.Content.ReadAsStringAsync().Result);


                return inputModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}