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
    public partial class ListUsers : ContentPage
    {
        public ListUsers()
        {
            InitializeComponent();
            llenarDatos();
        }

        public async void llenarDatos()
        {
            var personaList = await App.DBase.GetPersonasAsync();
            if (personaList != null)
            {
                lstPersonas.ItemsSource = personaList;
            }
        }

        private async void lstPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Personas)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.id.ToString()))
            {
                var persona = await App.DBase.GetPersonasByIdAsync(obj.id);
                if (persona != null)
                {
                    EditUsers edit = new EditUsers();
                    edit.BindingContext = persona;
                    await Navigation.PushAsync(edit);
                }
            }
        }
    }
}