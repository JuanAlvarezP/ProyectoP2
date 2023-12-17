using ProyectoP2.Models;

namespace ProyectoP2;

public partial class RegistrarCitas : ContentPage
{
    private List<CitasClase> listaCitas;

    public RegistrarCitas()
    {
        InitializeComponent();
        listaCitas = new List<CitasClase>(); // Inicializa la lista de citas
    }

    private void OnRegistrarCitaClicked(object sender, EventArgs e)
    {
        string nombrePropietario = nombrePropietarioEntry.Text;
        string motivoCita = motivoCitaEntry.Text;
        DateTime fechaHora = fechaDatePicker.Date; // Obtiene la fecha seleccionada

        // Crear una nueva cita
        CitasClase nuevaCita = new CitasClase
        {
            NombrePropietario = nombrePropietario,
            Motivo = motivoCita,
            FechaHora = fechaHora
            // Asignar otros valores si es necesario
        };

        listaCitas.Add(nuevaCita); // Agrega la nueva cita a la lista
    }
}