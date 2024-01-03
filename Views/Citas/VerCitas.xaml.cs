namespace ProyectoP2;
using ProyectoP2.Models;
using ProyectoP2.Views.Citas;
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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Actualizar la lista de citas cada vez que la página se muestre
        if (Preferences.ContainsKey("Citas"))
        {
            string citasString = Preferences.Get("Citas", string.Empty);
            List<CitasClase> citasGuardadas = System.Text.Json.JsonSerializer.Deserialize<List<CitasClase>>(citasString);

            // Establecer la lista de citas como origen de datos para la ListView
            listViewCitas.ItemsSource = null; // Limpia la lista existente
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

    private async void DetalleCitaClicked(object sender, EventArgs e)
    {
        // Obtener la cita seleccionada desde el parámetro del evento
        var citaSeleccionada = (CitasClase)((Button)sender).CommandParameter;

        // Aquí redirige a la página DetalleCita pasando la cita seleccionada como parámetro
        // Implementa la navegación según tus necesidades
        await Navigation.PushAsync(new DetalleCita(citaSeleccionada));
    }



}
