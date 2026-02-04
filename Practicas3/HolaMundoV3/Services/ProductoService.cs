using HolaMundo.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HolaMundo.Services
{
    public class ProductoService
    {
        private readonly IHttpClientFactory _httpClient;
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public ProductoService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            var client = _httpClient.CreateClient("Api");
            var request = new HttpRequestMessage(HttpMethod.Get, "Productos");
            request.Headers.Add("accept", "*/*");
            var response = await client.SendAsync(request);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var productos = JsonSerializer.Deserialize<List<Producto>>(jsonResponse, JsonOptions);
                return productos ?? new List<Producto>();
            }
            else
            {
                return new List<Producto>();
            }
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            var productos = await ObtenerTodosAsync();

            return productos.FirstOrDefault(p => p.Id == id);
        }

        public async Task<int> AgregarAsync(Producto producto)
        {
            var client = _httpClient.CreateClient("Api");
            var request = new HttpRequestMessage(HttpMethod.Post, "Productos");
            request.Headers.Add("accept", "*/*");
            var dto = MapToDto(producto);
            var json = JsonSerializer.Serialize(dto, JsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            var body = await ReadResponseBodyAsync(response);
            Console.WriteLine(body);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"POST Productos fallo: {response.StatusCode} - {body}");
            }

            var idDto = JsonSerializer.Deserialize<IdDto>(body, JsonOptions);
            return idDto?.Id ?? 0;
        }

        public async Task ActualizarAsync(Producto producto)
        {
            var client = _httpClient.CreateClient("Api");
            var request = new HttpRequestMessage(HttpMethod.Put, $"Productos/{producto.Id}");
            request.Headers.Add("accept", "*/*");
            var dto = MapToDto(producto);
            var json = JsonSerializer.Serialize(dto, JsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            var body = await ReadResponseBodyAsync(response);
            Console.WriteLine(body);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"PUT Productos fallo: {response.StatusCode} - {body}");
            }
        }

        public async Task BorrarAsync(int id)
        {
            var client = _httpClient.CreateClient("Api");
            var request = new HttpRequestMessage(HttpMethod.Delete, $"Productos/{id}?id={id}");
            request.Headers.Add("accept", "*/*");
            var response = await client.SendAsync(request);
            var body = await ReadResponseBodyAsync(response);
            Console.WriteLine(body);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"DELETE Productos fallo: {response.StatusCode} - {body}");
            }
        }

        private static ProductoDtoIn MapToDto(Producto producto)
        {
            return new ProductoDtoIn
            {
                EncodedKey = Guid.NewGuid(),
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                imagenUrl = producto.imagenUrl
            };
        }

        private static async Task<string> ReadResponseBodyAsync(HttpResponseMessage response)
        {
            if (response.Content == null)
            {
                return string.Empty;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
