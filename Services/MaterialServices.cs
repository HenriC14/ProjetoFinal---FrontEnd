using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using RecicladorBlazor.Models;

namespace RecicladorBlazor.Services
{
    public class MaterialServices
    {
        private readonly HttpClient _http;

        public MaterialServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MaterialViewModel>> GetAllAsync(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync("Personagens/GetAll");
            var responseContent = await response.Content.ReadAsStringAsync();
            List<MaterialViewModel> lista = new List<MaterialViewModel>();

            if (response.IsSuccessStatusCode)
            {
                lista = JsonSerializer.Deserialize<List<MaterialViewModel>>(responseContent, JsonSerializerOptions.Web);
                return lista;
            }
            else
            {
                throw new Exception(responseContent);
            }        
        }
        
    }
}