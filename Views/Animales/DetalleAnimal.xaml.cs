using ProyectoP2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoP2
{
    public partial class DetalleAnimal : ContentPage
    {
        private AnimalesClase animal;

        public DetalleAnimal(AnimalesClase animal)
        {
            InitializeComponent();
            this.animal = animal;
            BindingContext = animal;
        }

        private async void ActualizarAnimalClicked(object sender, EventArgs e)
        {
            if (BindingContext is AnimalesClase animal)
            {
                // Aquí puedes actualizar los datos del animal según lo que el usuario haya modificado
                // Por ejemplo, puedes usar System.Text.Json para actualizar y guardar los datos en Preferencias
                animal.NombreAni = NombreAniEntry.Text;
                animal.Especie = EspecieEntry.Text;
                animal.Raza = RazaEntry.Text;
                animal.FechaNacimiento = FechaNacimientoPicker.Date; // Actualizar la fecha de nacimiento
                animal.Genero = GeneroPicker.SelectedItem?.ToString(); // Actualizar el género

                // Ejemplo de actualización de Observaciones:
                animal.Observaciones = ObservacionesEntry.Text; // Cambiar por el valor actualizado

                // Ahora, puedes guardar el animal actualizado en las preferencias o en tu almacenamiento persistente
                var listaAnimales = new List<AnimalesClase>(); // Reemplaza esto con tu forma de obtener la lista actualizada
                listaAnimales.Add(animal); // Agrega el animal actualizado a la lista

                // Convierte la lista de animales a formato JSON para almacenarla en Preferencias
                string serializedAnimales = System.Text.Json.JsonSerializer.Serialize(listaAnimales);
                Preferences.Set("Animales", serializedAnimales);

                // Puedes mostrar un mensaje indicando que se actualizó correctamente
                await DisplayAlert("Éxito", "El animal se actualizó correctamente", "OK");
            }
        }
    }
}
