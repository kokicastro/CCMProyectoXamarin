using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarinCCM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            BotonArtsTemporada.Clicked += BotonArtsTemporada_Clicked;

            BotonPromociones.Clicked += BotonPromociones_Clicked;
        }

        private void BotonPromociones_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArtsPromociones());
        }

        private void BotonArtsTemporada_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArtsTemporada());
        }
    }
}
