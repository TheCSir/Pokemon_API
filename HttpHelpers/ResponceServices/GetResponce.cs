using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelpers.ResponceServices
{
    public static class GetResponce
    {
        public static async Task<HttpResponseMessage> GetResponseString(Uri inputUri)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
                try
                {
                    var response = await httpClient.GetAsync(inputUri);
                    response.EnsureSuccessStatusCode();
                    return response;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
