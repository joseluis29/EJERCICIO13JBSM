using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJERCICIO13JBSM.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO13JBSM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUsers : ContentPage
    {
        public EditUsers()
        {
            InitializeComponent();
        }
        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {
                Personas personas = new Personas()
                {
                    id = Convert.ToInt32(txtid.Text),
                    nombres = txtnombres.Text,
                    apellidos = txtapellidos.Text,
                    edad = Convert.ToInt32(txtedad.Text),
                    correo = txtcorreo.Text,
                    direccion = txtdireccion.Text
                };
                await App.DBase.SavePersonaAsync(personas);
                await DisplayAlert("Actualizado", "Se actualizo de manera exitosa!", "Ok");
                await Navigation.PopToRootAsync();
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("ADVERTENCIA", "Desea eliminar el registro?", "Yes", "No");
            if (action)
            {
                var persona = await App.DBase.GetPersonasByIdAsync(Convert.ToInt32(txtid.Text));
                if (persona != null)
                {
                    await App.DBase.DeletePersonaAsync(persona);
                    await DisplayAlert("Eliminado", "Se elimino de manera exitosa!", "Ok");
                    await Navigation.PopToRootAsync();
                }
            }
        }
    }
}