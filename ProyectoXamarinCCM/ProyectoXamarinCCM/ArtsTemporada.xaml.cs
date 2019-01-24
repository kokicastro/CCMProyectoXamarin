using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using ProyectoXamarinCCM.Modelos;
using ProyectoXamarinCCM.Servicios;
using Plugin.Connectivity;
using ProyectoXamarinCCM.Modelos;
using System.Collections.ObjectModel;

namespace ProyectoXamarinCCM
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtsTemporada : ContentPage
    {
        //public ArtsTemporada ()
        //{
        public APITemp DataService { get; } = new APITemp();
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
        public Command AgregarCommand { get; set; }
        public Command RefrescarCommand { get; set; }

        private string _data = @"[
		{
			""imagen"": ""pillow"",
			""codigo"": 5.0,
			""precio"": 1.0
		}]";

        public string Data { get => _data; }

        public ArtsTemporada()
        {
            BindingContext = this;

            AgregarCommand = new Command(() => {
                Items.Add(new ArticuloCCM
                {
                    codigo = $"Producto {(Items.Count + 1)}"
                }
                );

                // No tiene ningun efecto hacer ListViewDatos.ItemsSource = new int[] { 1, 2, 3};
            });

            IsBusy = true;
            RefrescarCommand = new Command(() => Refrescar());

            InitializeComponent();

            ListViewDatosTemp.ItemSelected += ListViewDatosTemp_ItemSelected;
        }

        void ListViewDatosTemp_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem;

            var articulo = selectedItem as ArticuloCCM;

            Navigation.PushAsync(
                new DetalleArtsTemp(articulo)
                );
        }

        private async void Refrescar()
        {
            IsBusy = false;

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Imposible continuar", "No hay conexion a internet", "Continuar");
                return;
            }
            try
            {
                var data = await DataService.GetStringAsync();

                foreach (var item in data)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ha ocurrido un error", ex.Message, "Continuar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Refrescar();
        }

    }
}