using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Patinaje_Torneos.Client.Services
{
    public class Servicio: IServicio
    {
        private readonly HttpClient httpClient;
        public Servicio(HttpClient http)
        {
            httpClient = http;
        }
        private JsonSerializerOptions OpcionesPorDefectoJSON =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<List<T>> GetList<T>(string url)
        {
            return await httpClient.GetFromJsonAsync<List<T>>(url);
        }

        public async Task<HttpResponseWrapper<T>> GetHttp<T>(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHTTP, OpcionesPorDefectoJSON);
                return new HttpResponseWrapper<T>(response, false, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHTTP);
            }
        }
        public async Task<T> Get<T>(string url)
        {
            return await httpClient.GetFromJsonAsync<T>(url);
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        /*public Task Post<T, TResponse>(string url, T enviar)
        {
            throw new NotImplementedException();
        }*/

        public async Task Put<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, enviarContent);
        }
        public async Task Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
        }
        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }
    }
}
