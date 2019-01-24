using System;
using System.Collections.Generic;
using ProyectoXamarinCCM.Modelos;
using ProyectoXamarinCCM.Servicios;
using Xamarin.Forms;

namespace ProyectoXamarinCCM
{
    public partial class DetalleArtsPromo : ContentPage
    {
        public DetalleArtsPromo()
        {
            InitializeComponent();
        }

        public DetalleArtsPromo(ArticuloCCM producto)
        {
            // 1) BindingContext alimenta la pantalla

            BindingContext = producto;

            //
            InitializeComponent();

            //botonLlamada.Command = new Command(() => {
            //    IDialer dialer = DependencyService.Get<IDialer>();

            //    if (dialer != null)
            //    {
            //        dialer.Call("555-5555");
            //    }
                // 1 linea: dialer?.Call("555-5555");
            //});
        }
    }
}
