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
    public partial class Page2 : ContentPage
    {
        private string Url = "https://apigatos.azurewebsites.net/api/Gatos";
        public Page2()
        {
            InitializeComponent();
            CargarGatos();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void CargarGatos()
        {
            GridGatos.RowDefinitions.Clear();
            GridGatos.ColumnDefinitions.Clear();
            GridGatos.Children.Clear();
            var gatos = APIConsumer.Gatos(Url);
            if (gatos.Length != 0)
            {
                int i = 0;
                foreach (Gato gato in gatos)
                {
                    Grid grid = new Grid();
                    GridGatos.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(grid, i);
                    ColumnDefinition columna1 = new ColumnDefinition();
                    columna1.Width = new GridLength(40);
                    grid.ColumnDefinitions.Add(columna1);

                    ColumnDefinition columna2 = new ColumnDefinition();
                    columna2.Width = new GridLength(150);
                    grid.ColumnDefinitions.Add(columna2);

                    ColumnDefinition columna3 = new ColumnDefinition();
                    columna3.Width = new GridLength(60);
                    grid.ColumnDefinitions.Add(columna3);

                    ColumnDefinition columna4 = new ColumnDefinition();
                    columna4.Width = new GridLength(150);
                    grid.ColumnDefinitions.Add(columna4);

                    Label id = new Label();
                    Label nombre = new Label();
                    Label edad = new Label();
                    Label color = new Label();



                    id.Text = gato.Id + "";
                    nombre.Text = gato.Nombre + "";
                    edad.Text = gato.Edad + "";
                    color.Text = gato.Color + "";
                   


                    Grid.SetColumn(id, 0);
                    Grid.SetColumn(nombre, 1);
                    Grid.SetColumn(edad, 2);
                    Grid.SetColumn(color, 3);

                    grid.Children.Add(id);
                    grid.Children.Add(nombre);
                    grid.Children.Add(edad);
                    grid.Children.Add(color);
                    GridGatos.Children.Add(grid);
                    i += 2;
                }
            }
        }
    }
}