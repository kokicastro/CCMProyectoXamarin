using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProyectoXamarinCCM.Modelos;
using Newtonsoft.Json;

namespace ProyectoXamarinCCM.Servicios
{
    public class API
    {
        private const string WEB_SERVICE_URL = "http://cloud-services.azurewebsites.net/api/products";

        public async Task<Articulo[]> GetStringAsync()
        {
            // Dispose HttpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_SERVICE_URL);

                // using System.Net.Http.Headers;
                // text/xml

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetStringAsync("");

                var data = JsonConvert.DeserializeObject<Articulo[]>(response);

                Debug.WriteLine(
                    data
                );

                return data;
            };
        }

        public async Task<Articulo[]> GetAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(WEB_SERVICE_URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("");

            if (!response.IsSuccessStatusCode)
            {
                return new Articulo[0];
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Articulo[]>(content);

            Debug.WriteLine(
                data
            );

            return data;
        }
    }
}
