using HolaMundo.ConsumoWSV2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HolaMundo.ConsumoWSV2.Services
{
    public class CodigoPostalService
    {
        public async Task<CodigoPostalDTO> CodigoPostalAleatorio()
        {
            var client = new HttpClient();
            var url = "https://utilidades.vmartinez84.xyz/api/CodigosPostales/Aleatorio";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            var response = await client.SendAsync(request);
            var data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var CodigoPData = JsonSerializer.Deserialize<CodigoPostalDTO>(data, options);

            if (CodigoPData == null)
                throw new InvalidOperationException("No se pudo deserializar el código postal.");

            return CodigoPData;
        }
    }
}
