using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EJERCICIO13JBSM.Models;

namespace EJERCICIO13JBSM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUsers : ContentPage
    {
        public CreateUsers()
        {
            InitializeComponent();
        }

        private async void btnregistrar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtnombres.Text) && !string.IsNullOrEmpty(txtapellidos.Text) && !string.IsNullOrEmpty(txtedad.Text) && !string.IsNullOrEmpty(txtcorreo.Text) && !string.IsNullOrEmpty(txtdireccion.Text))
            {
                Personas personas = new Personas
                {
                    nombres = txtnombres.Text,
                    apellidos = txtapellidos.Text,
                    edad = int.Parse(txtedad.Text),
                    correo = txtcorreo.Text,
                    direccion = txtdireccion.Text
                };
                await App.DBase.SavePersonaAsync(personas);
                LimpiarTxt();
                await DisplayAlert("Registro", "Se registro de manera exitosa!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Debe llenar todos los campos.", "Ok");
            }
        }
        private void LimpiarTxt()
        {
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtedad.Text = "";
            txtcorreo.Text = "";
            txtdireccion.Text = "";
        }
    }
}