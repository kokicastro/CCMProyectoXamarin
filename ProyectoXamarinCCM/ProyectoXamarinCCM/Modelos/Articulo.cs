using System;
using Newtonsoft.Json;

namespace ProyectoXamarinCCM.Modelos
{
    public class Articulo
    {
        [JsonProperty(PropertyName = "Name")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public double Precio { get; set; }

        [JsonProperty(PropertyName = "Quantity")]
        public decimal Cantidad { get; set; }

        public string RutaImagen { get; set; } = "https://cdn0.iconfinder.com/data/icons/business-mix/512/cargo-512.png";
    }
}
