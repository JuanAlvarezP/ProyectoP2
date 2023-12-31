using ProyectoP2.Models;
using System.Windows.Input;

namespace ProyectoP2;

public partial class VerAnimales : ContentPage
{
    public ICommand DeleteCommand { get; }

    public VerAnimales()
    {
        InitializeComponent();

        // Obtener la lista de animales guardados de las preferencias de la aplicación
        if (Preferences.ContainsKey("Animales"))
        {
            string animalesString = Preferences.Get("Animales", string.Empty);
            List<AnimalesClase> animalesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<AnimalesClase>>(animalesString);

            // Establecer la lista de animales como origen de datos para el ListView
            listViewAnimales.ItemsSource = animalesGuardados;
        }

        DeleteCommand = new Command<AnimalesClase>(async (animal) => await EliminarAnimal(animal));
        BindingContext = this;
    }

    private async Task EliminarAnimal(AnimalesClase animal)
    {
        bool answer = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar este animal?", "Sí", "No");

        if (answer)
        {
            if (listViewAnimales.ItemsSource is IList<AnimalesClase> animales)
            {
                animales.Remove(animal);

                // Guardar los animales actualizados en las preferencias
                var serializedAnimales = System.Text.Json.JsonSerializer.Serialize(animales);
                Preferences.Set("Animales", serializedAnimales);

                // Actualizar la lista en la interfaz
                listViewAnimales.ItemsSource = null;
                listViewAnimales.ItemsSource = animales;
            }
        }
    }
    
}