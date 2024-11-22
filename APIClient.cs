using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LR5
{
    internal class APIClient
    {
        private readonly HttpClient _httpClient;

        public APIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponseModel<T>> GetAsync<T>(string url)
        {
            var response = new ApiResponseModel<T>();

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
                response.StatusCode = (int)httpResponse.StatusCode;

                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    response.Data = JsonSerializer.Deserialize<List<T>>(content);
                    response.Message = "Request successful";
                }
                else
                {
                    response.Message = "Request failed";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = $"Error occurred: {ex.Message}";
            }

            return response;
        }

        public async Task<ApiResponseModel<T>> PostAsync<T>(string url, object payload)
        {
            var response = new ApiResponseModel<T>();

            try
            {
                string reqBody = "";
                foreach(PropertyInfo property in payload.GetType().GetProperties()) {
                    if(property.GetValue(payload) != null) {
                        reqBody += $"{property.Name}={property.GetValue(payload)}&";
                    }
                }
                StringContent stringContent = new StringContent(reqBody, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = await _httpClient.PostAsync(url, stringContent);
                response.StatusCode = (int)httpResponse.StatusCode;

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync();
                    List<T> temp = new List<T>{
                        JsonSerializer.Deserialize<T>(responseContent)
                    };
                    response.Data = temp;
                    response.Message = "Request successful";
                }
                else
                {
                    string responseContent = await httpResponse.Content.ReadAsStringAsync();
                    response.Message = $"Request failed: {responseContent}" ;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = $"Error occurred: {ex.Message}";
            }

            return response;
        }
    }
}
