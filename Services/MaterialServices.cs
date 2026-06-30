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

            var response = await _http.GetAsync("Material/GetAll");
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
        
        public async Task<MaterialViewModel> InsertAsync(string token, MaterialViewModel material)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonSerializer.Serialize(material));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _http.PostAsync("materiais", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                material.Id = Convert.ToInt32(responseContent);
                return material;
            }
            else
            {
                throw new Exception(responseContent);
            }
        }
    
        public async Task<MaterialViewModel> GetByIdAsync(string token, int id)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync($"materiais/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            MaterialViewModel material = new MaterialViewModel();

            if (response.IsSuccessStatusCode)
            {
                material = JsonSerializer
                    .Deserialize<MaterialViewModel>(responseContent, JsonSerializerOptions.Web);
                return material;
            }
            else
            {
                throw new Exception(responseContent);
            }
        }

        public async Task<int> EditAsync(string token, MaterialViewModel material)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonSerializer.Serialize(material));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _http.PutAsync("materiais", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                int linhasAfetadas = Convert.ToInt32(responseContent);
                return linhasAfetadas;
            }
            else
            {
                throw new Exception(responseContent);
            }
        }

        public async Task<int> DeleteAsync(string token, int id)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.DeleteAsync($"materiais/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                int linhasAfetadas = Convert.ToInt32(responseContent);
                return linhasAfetadas;
            }
            else
            {
                throw new Exception(responseContent);
            }
        }
    }
}