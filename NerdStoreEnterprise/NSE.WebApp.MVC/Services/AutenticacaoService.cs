using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(UsuarioLogin usuarioLogin)
        {
            StringContent loginContent = new StringContent(
                JsonSerializer.Serialize(usuarioLogin),Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await _httpClient
                .PostAsync("https://localhost:5001/api/identidade/autenticar", loginContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            StringContent registroContent = new StringContent(
               JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8,
               "application/json"
           );

            HttpResponseMessage response = await _httpClient
                .PostAsync("https://localhost:5001/api/identidade/nova-conta", registroContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
