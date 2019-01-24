using System;
using Newtonsoft.Json;

namespace ProyectoXamarinCCM.Modelos
{
    public class ArticuloCCM
    {
        [JsonProperty(PropertyName = "articulo")]
        public string codigo { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string descripcion { get; set; }

        [JsonProperty(PropertyName = "precio")]
        public decimal precio { get; set; }

        [JsonProperty(PropertyName = "imagen")]
        public String imagen { get; set; }

        //public string RutaImagen { get; set; } = "https://cdn0.iconfinder.com/data/icons/business-mix/512/cargo-512.png";
    }
}
