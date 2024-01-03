using ProyectoP2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoP2
{
    public partial class VerAnimales : ContentPage
    {
        public VerAnimales()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("Animales"))
            {
                string animalesString = Preferences.Get("Animales", string.Empty);
                List<AnimalesClase> animalesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<AnimalesClase>>(animalesString);
                listViewAnimales.ItemsSource = animalesGuardados;
                BindingContext = this;
            }
        }

        private async void EliminarAnimalClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is AnimalesClase animal)
            {
                bool answer = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar este animal?", "Sí", "No");

                if (answer)
                {
                    if (listViewAnimales.ItemsSource is IList<AnimalesClase> animales)
                    {
                        animales.Remove(animal);
                        var serializedAnimales = System.Text.Json.JsonSerializer.Serialize(animales);
                        Preferences.Set("Animales", serializedAnimales);
                        listViewAnimales.ItemsSource = null;
                        listViewAnimales.ItemsSource = animales;
                    }
                }
            }
        }

        private async void DetalleAnimalClicked(object sender, EventArgs e)
        {
            var animalSeleccionado = (AnimalesClase)((Button)sender).CommandParameter;

            // Redirigir a la página DetalleAnimal pasando el animal seleccionado como parámetro
            await Navigation.PushAsync(new DetalleAnimal(animalSeleccionado));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Actualizar la lista de animales cada vez que la página se muestre
            if (Preferences.ContainsKey("Animales"))
            {
                string animalesString = Preferences.Get("Animales", string.Empty);
                List<AnimalesClase> animalesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<AnimalesClase>>(animalesString);
                listViewAnimales.ItemsSource = null; // Limpiar la lista existente
                listViewAnimales.ItemsSource = animalesGuardados;
                BindingContext = this;
            }
        }



    }
}
