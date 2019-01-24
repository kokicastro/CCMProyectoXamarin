using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProyectoXamarinCCM.Modelos;
using Newtonsoft.Json;

namespace ProyectoXamarinCCM.Servicios
{
    public class APITemp
    {
        private const string WEB_SERVICE_URL = "http://186.96.88.106:8095/API/ConsultaDeTodoUnPoco?id_usuario=&token=1&pagina=2&registros=20";

        public async Task<ArticuloCCM[]> GetStringAsync()
        {
            // Dispose HttpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_SERVICE_URL);

                // using System.Net.Http.Headers;
                // text/xml

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetStringAsync("");

                var data = JsonConvert.DeserializeObject<ArticuloCCM[]>(response);

                Debug.WriteLine(
                    data
                );

                return data;
            };
        }

        public async Task<ArticuloCCM[]> GetAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(WEB_SERVICE_URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("");

            if (!response.IsSuccessStatusCode)
            {
                return new ArticuloCCM[0];
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ArticuloCCM[]>(content);

            Debug.WriteLine(
                data
            );

            return data;
        }
    }
}
