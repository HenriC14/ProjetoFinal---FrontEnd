using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using RecicladorBlazor.Models;

namespace RecicladorBlazor.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _http;
        public UsuarioService(HttpClient http)
        {
            _http = http;
        }
                public async Task<UsuarioViewModel> RegistrarAsync(UsuarioViewModel usuario)
        {
            var content = new StringContent(JsonSerializer.Serialize(usuario));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _http.PostAsync("usuario/autenticar", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                usuario = JsonSerializer
                .Deserialize<UsuarioViewModel>(responseContent, JsonSerializerOptions.Web);
                return usuario;
            }
            else
            {
                throw new Exception(responseContent);
            }
        }
    }
}