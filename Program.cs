using LR5;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LR5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            HttpClient httpClient = new HttpClient();
            APIClient apiClient = new APIClient(httpClient);

            string apiUrl = "https://languagetool.org/api/v2/";

            Console.WriteLine("GET(languages):");
            var languagesResponse = await apiClient.GetAsync<LanguagesResponseModel>(apiUrl + "languages");
            Console.WriteLine($"Status Code: {languagesResponse.StatusCode}");
            Console.WriteLine($"Message: {languagesResponse.Message}");
            Console.WriteLine($"Data: {JsonSerializer.Serialize(languagesResponse.Data)}");

            Console.WriteLine("\nPOST(check):");
            var payload = new CheckRequestModel("Hello, wold!", "en-US");
            var checkResponse = await apiClient.PostAsync<CheckResponseModel>(apiUrl + "check", payload);
            Console.WriteLine($"Status Code: {checkResponse.StatusCode}");
            Console.WriteLine($"Message: {checkResponse.Message}");
            Console.WriteLine($"Data: {JsonSerializer.Serialize(checkResponse.Data)}");

        }
    }
}