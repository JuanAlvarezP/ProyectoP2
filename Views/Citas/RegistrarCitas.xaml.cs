using ProyectoP2.Models;
    


namespace ProyectoP2;

public partial class RegistrarCitas : ContentPage
{
    public CitasClase NuevaCita { get; set; }           

    public RegistrarCitas()
    {
        InitializeComponent();
        NuevaCita = new CitasClase();
        BindingContext = NuevaCita;
        NuevaCita.FechaHora = DateTime.Now;
    }

    private async void RegistrarClicked(object sender, EventArgs e)
    {
        // Guardar la nueva cita en las preferencias de la aplicación
        List<CitasClase> citasGuardadas = new List<CitasClase>();

        // Obtener las citas existentes, si las hay
        if (Preferences.ContainsKey("Citas"))
        {
            string citasString = Preferences.Get("Citas", string.Empty);
            citasGuardadas = System.Text.Json.JsonSerializer.Deserialize<List<CitasClase>>(citasString);
        }

        // Agregar la nueva cita a la lista
        citasGuardadas.Add(NuevaCita);

        // Serializar la lista de citas y guardarlas en las preferencias
        string serializedCitas = System.Text.Json.JsonSerializer.Serialize(citasGuardadas);
        Preferences.Set("Citas", serializedCitas);

        if (string.IsNullOrWhiteSpace(NuevaCita.Motivo) ||
                 string.IsNullOrWhiteSpace(NuevaCita.NombreAnimal) ||
                 string.IsNullOrWhiteSpace(NuevaCita.NombrePropietario) ||
                 string.IsNullOrWhiteSpace(NuevaCita.NumeroTelefonoPropietario) ||
                 string.IsNullOrWhiteSpace(NuevaCita.Observaciones))
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos obligatorios.", "OK");
            return;
        }

        // Después de guardar, puedes navegar a la página de ver citas:
        Navigation.PushAsync(new VerCitas());
    }
}