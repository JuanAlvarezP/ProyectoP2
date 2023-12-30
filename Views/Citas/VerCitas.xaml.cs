namespace ProyectoP2;
using ProyectoP2.Models;
using System.Windows.Input;

public partial class VerCitas : ContentPage
{
    public VerCitas()
    {
        InitializeComponent();

        // Obtener las citas guardadas de las preferencias de la aplicación
        if (Preferences.ContainsKey("Citas"))
        {
            string citasString = Preferences.Get("Citas", string.Empty);
            List<CitasClase> citasGuardadas = System.Text.Json.JsonSerializer.Deserialize<List<CitasClase>>(citasString);

            // Establecer la lista de citas como origen de datos para la ListView
            listViewCitas.ItemsSource = citasGuardadas;

            BindingContext = this;
        }
    }

    private async void EliminarCitaClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is CitasClase cita)
        {
            bool answer = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar la cita?", "Sí", "No");

            if (answer)
            {
                if (listViewCitas.ItemsSource is IList<CitasClase> citas)
                {
                    citas.Remove(cita);

                    // Guardar las citas actualizadas en las preferencias
                    var serializedCitas = System.Text.Json.JsonSerializer.Serialize(citas);
                    Preferences.Set("Citas", serializedCitas);

                    // Actualizar la lista en la interfaz
                    listViewCitas.ItemsSource = null;
                    listViewCitas.ItemsSource = citas;
                }
            }
        }
    }

    
}
