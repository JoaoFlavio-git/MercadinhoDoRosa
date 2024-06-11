using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ApiDoMercadinho.Models;

namespace MercadoriaReges.Services
{
    public interface IApiService
    {
        Task<List<Mercado>> GetMercadosAsync();
        Task<Mercado> GetMercadoAsync(int id);
        Task<HttpResponseMessage> PostMercadoAsync(Mercado mercado);
        Task<HttpResponseMessage> PutMercadoAsync(int id, Mercado mercado);
        Task<HttpResponseMessage> DeleteMercadoAsync(int id);

        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int id);
        Task<HttpResponseMessage> PostClienteAsync(Cliente cliente);
        Task<HttpResponseMessage> PutClienteAsync(int id, Cliente cliente);
        Task<HttpResponseMessage> DeleteClienteAsync(int id);
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Mercado>> GetMercadosAsync()
        {
            var response = await _httpClient.GetAsync("api/Mercadinho");
            response.EnsureSuccessStatusCode();

            var mercados = await response.Content.ReadFromJsonAsync<List<Mercado>>();
            return mercados.OrderBy(mercado => mercado.Nome).ToList();
        }

        public async Task<Mercado> GetMercadoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Mercadinho/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Mercado>();
        }

        public async Task<HttpResponseMessage> PostMercadoAsync(Mercado mercado)
        {
            return await _httpClient.PostAsJsonAsync("api/Mercadinho/", mercado);
        }

        public async Task<HttpResponseMessage> PutMercadoAsync(int id, Mercado mercado)
        {
            return await _httpClient.PutAsJsonAsync($"api/Mercadinho/{id}", mercado);
        }

        public async Task<HttpResponseMessage> DeleteMercadoAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/Mercadinho/{id}");
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            var response = await _httpClient.GetAsync("api/clientes");
            response.EnsureSuccessStatusCode();

            var clientes = await response.Content.ReadFromJsonAsync<List<Cliente>>();
            return clientes.OrderBy(cliente => cliente.Name).ToList();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/clientes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Cliente>();
        }

        public async Task<HttpResponseMessage> PostClienteAsync(Cliente cliente)
        {
            return await _httpClient.PostAsJsonAsync("api/clientes/", cliente);
        }

        public async Task<HttpResponseMessage> PutClienteAsync(int id, Cliente cliente)
        {
            return await _httpClient.PutAsJsonAsync($"api/clientes/{id}", cliente);
        }

        public async Task<HttpResponseMessage> DeleteClienteAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/clientes/{id}");
        }
    }
}
