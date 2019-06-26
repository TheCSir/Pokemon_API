using System;
using System.Net.Http;

namespace HttpHelpers.ResponseServices
{
    /// <summary>
    /// This class contains helper methods for Http response handling
    /// </summary>
    public static class GetResponse
    {
        /// <summary>
        /// This method will return a http response from a url
        /// </summary>
        /// <param name="inputUri"> input url</param>
        /// <returns>
        ///     response from url
        /// </returns>
        public static HttpResponseMessage GetResponseString(Uri inputUri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
                try
                {
                    var response = httpClient.GetAsync(inputUri).Result;
                    response.EnsureSuccessStatusCode();
                    return response;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
    }
}