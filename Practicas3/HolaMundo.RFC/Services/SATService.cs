using HolaMundo.RFC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HolaMundo.RFC.Services
{
    public  class SATService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SATService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GeneraRFCAsync(SolicitudRFCDTO solicitud)
        {
            await Task.Delay(5000);

            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "Rfc");
            request.Headers.Add("accept", "application/json");
            var json = JsonSerializer.Serialize(solicitud);
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            //Console.WriteLine(await response.Content.ReadAsStringAsync());

            if(response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                RFCDTO rfcResponse = JsonSerializer.Deserialize<RFCDTO>(jsonResponse);

                return rfcResponse.Rfc;
            }
            else
            {
                return "No se pudo generar el RFC";
            }
        }
    }
}
