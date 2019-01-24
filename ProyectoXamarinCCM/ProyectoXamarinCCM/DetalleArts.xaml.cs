﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoXamarinCCM.Modelos;

namespace ProyectoXamarinCCM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalleArts : ContentPage
	{
		public DetalleArts ()
		{
			InitializeComponent ();
		}

        public DetalleArts(Articulo articulo)
        {
            // 1) BindingContext alimenta la pantalla

            BindingContext = articulo;

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