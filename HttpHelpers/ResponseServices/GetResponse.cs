using System;
using System.Net.Http;

namespace HttpHelpers.ResponseServices
{
    public static class GetResponse
    {
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