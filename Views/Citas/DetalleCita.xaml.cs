using ProyectoP2.Models;
using System.Globalization;

namespace ProyectoP2.Views.Citas;

public partial class DetalleCita : ContentPage
{
    private CitasClase cita;

    public DetalleCita(CitasClase cita)
    {
        InitializeComponent();
        this.cita = cita;
        BindingContext = this.cita; 
    }

    private async void ActualizarCitaClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(FechaHoraEntry.Text) &&
            !string.IsNullOrWhiteSpace(MotivoEntry.Text))
        {
            // Guarda las citas actualizadas en las preferencias
            if (Preferences.ContainsKey("Citas"))
            {
                string citasString = Preferences.Get("Citas", string.Empty);
                List<CitasClase> citasGuardadas = System.Text.Json.JsonSerializer.Deserialize<List<CitasClase>>(citasString);

                // Encuentra y actualiza la cita en la lista
                var citaAActualizar = citasGuardadas.FirstOrDefault(c => c.Id == this.cita.Id);
                if (citaAActualizar != null)
                {
                    citaAActualizar.FechaHoraString = FechaHoraEntry.Text;
                    citaAActualizar.Motivo = MotivoEntry.Text;
                    citaAActualizar.NombreAnimal = NombreAnimalEntry.Text;
                    citaAActualizar.NombrePropietario = NombrePropietarioEntry.Text;
                    citaAActualizar.NumeroTelefonoPropietario = TelefonoPropietarioEntry.Text;
                    citaAActualizar.Observaciones = ObservacionesEntry.Text;



                    var serializedCitas = System.Text.Json.JsonSerializer.Serialize(citasGuardadas);
                    Preferences.Set("Citas", serializedCitas);
                }
            }

            await DisplayAlert("Éxito", "La cita se actualizó correctamente", "OK");

            // Redirigir a VerCitas
            await Navigation.PopAsync(); // Esto cerrará la página actual (DetalleCita)
        }
        else
        {
            // Mensaje de error si no se han completado todos los campos necesarios
            DisplayAlert("Error", "Por favor, completa todos los campos", "OK");
        }


    }



}