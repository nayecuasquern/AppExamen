using AppExamen.Code;
using AppExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamen.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public string Url = "https://apigatos.azurewebsites.net/api/Gatos";

        public Page1()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }


        private void Button_ListaGatos(object sender, EventArgs e)
        {
            var vl = new Page2();
            Navigation.PushAsync(vl);
        }
        private void Button_Leer(object sender, EventArgs e)
        {
            var gato = APIConsumer.Gato(Url, txtId.Text);

            if (gato != null)
            {
                gato.Id = int.Parse(txtId.Text);
                gato.Nombre = txtNombre.Text;
                gato.Edad = 2;  //int.Parse(txtEdad.Text);
                gato.Color = txtColor.Text;
            }
        }
        private void Button_Registrar(object sender, EventArgs e)
        {
            Gato gato = new Gato();
            gato.Id = int.Parse(txtId.Text);
            gato.Nombre = txtNombre.Text;
            gato.Edad = int.Parse(txtEdad.Text);
            gato.Color = txtColor.Text;


            string result = APIConsumer.CreateGato(Url, gato);
            if (result == "OK")
            {
                txtId.Text = "";
                txtNombre.Text = "";
                txtEdad.Text = "";
                txtColor.Text = "";

                DisplayAlert("Registrar", "Se registró el gato con éxito", "OK");
            }
        }
        private void Button_Actualizar(object sender, EventArgs e)
        {
            Gato gato = new Gato();
            gato.Id = int.Parse(txtId.Text);
            gato.Nombre = txtNombre.Text;
            gato.Edad = int.Parse(txtEdad.Text);
            gato.Color = txtColor.Text;

            string result = APIConsumer.CreateGato(Url, gato);
            if (result == "OK")
            {
                txtId.Text = "";
                txtNombre.Text = "";
                txtEdad.Text = "";
                txtColor.Text = "";

                DisplayAlert("Actualizar", "Se actualizó el gato con éxito", "OK");
            }
            
        }
        private async void Button_Eliminar(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlert(title: "Alerta", message: "¿Desea eliminar el gato?", accept: "Aceptar", cancel: "Cancelar");

            if (respuesta)
            {
                string result = APIConsumer.DeleteGato(Url, txtId.Text);
                if (result == "OK")
                {
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtEdad.Text = "";
                    txtColor.Text = "";
                    await DisplayAlert("Eliminar", "Se eliminó el gato", "OK");
                }
            }


        }
    }
}