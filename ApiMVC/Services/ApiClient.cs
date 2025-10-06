using ApiMVC.Models;
using System.Text;
using System.Text.Json;

namespace ApiMVC.Services
{
    public class ApiClient : IApiclient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiClient(HttpClient httpClient) 
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync() 
        {
            try
            {
                var response = await _httpClient.GetAsync("productos");
                
                if (response.IsSuccessStatusCode)
                {
                    var productos = await response.Content.ReadFromJsonAsync<IEnumerable<Producto>>(_jsonOptions);
                    return productos ?? Enumerable.Empty<Producto>();
                }
                else
                {
                    throw new HttpRequestException($"API retornó {response.StatusCode}: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos: {ex.Message}", ex);
            }
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"productos/{id}");
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Producto>(_jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener producto {id}: {ex.Message}", ex);
            }
        }

        public async Task<Producto?> CreateProductoAsync(Producto producto)
        {
            try
            {
                var json = JsonSerializer.Serialize(producto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("productos", content);
                
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Producto>(_jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear producto: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateProductoAsync(int id, Producto producto)
        {
            try
            {
                var json = JsonSerializer.Serialize(producto, _jsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PutAsync($"productos/{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar producto {id}: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"productos/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto {id}: {ex.Message}", ex);
            }
        }
    }
}
