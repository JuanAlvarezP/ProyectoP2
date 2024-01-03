using ProyectoP2.Models;

namespace ProyectoP2;

public partial class RegistrarAnimales : ContentPage
{
	public RegistrarAnimales()
    {
        InitializeComponent();
    }

    private async void RegistrarClicked(object sender, EventArgs e)
    {
        // Obtener los valores de las entradas
        string nombre = entryNombre.Text;
        string especie = entryEspecie.Text;
        string raza = entryRaza.Text;
        DateTime fechaNacimiento = datePickerFechaNacimiento.Date;
        string genero = pickerGenero.SelectedItem?.ToString();
        string observaciones = entryObservaciones.Text;

        // Validar los datos ingresados
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(especie) ||
            string.IsNullOrWhiteSpace(raza) ||
            string.IsNullOrWhiteSpace(genero) ||
            fechaNacimiento == DateTime.MinValue)
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos obligatorios.", "OK");
            return;
        }
        // Crear una nueva instancia de la clase AnimalesClase con los datos ingresados
        AnimalesClase nuevoAnimal = new AnimalesClase()
        {
            NombreAni = nombre,
            Especie = especie,
            Raza = raza,
            FechaNacimiento = fechaNacimiento,
            Genero = genero,
            Observaciones = observaciones
        };

        List<AnimalesClase> animalesGuardados = new List<AnimalesClase>();

        if (Preferences.ContainsKey("Animales"))
        {
            string animalesString = Preferences.Get("Animales", string.Empty);
            animalesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<AnimalesClase>>(animalesString);
        }

        // Agregar el nuevo animal a la lista de animales guardados
        animalesGuardados.Add(nuevoAnimal);

        // Serializar la lista actualizada de animales a formato JSON
        string serializedAnimales = System.Text.Json.JsonSerializer.Serialize(animalesGuardados);

        // Guardar la lista de animales en las preferencias
        Preferences.Set("Animales", serializedAnimales);

        // Mostrar un mensaje de éxito
        DisplayAlert("Éxito", "Se ha registrado el animal correctamente", "Aceptar");

        // Puedes agregar aquí la navegación a otra página si es necesario
    }
}