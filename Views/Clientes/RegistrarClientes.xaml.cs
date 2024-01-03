using ProyectoP2.Models;
using System.Text.Json;

namespace ProyectoP2;

public partial class RegistrarClientes : ContentPage
{
    public RegistrarClientes()
    {
        InitializeComponent();
    }

    private void GuardarClienteClicked(object sender, EventArgs e)
    {

        string nombre = entryNombre.Text;
        string apellido = entryApellido.Text;
        string correo = entryCorreo.Text;
        string telefono = entryTelefono.Text;
        string direccion = entryDireccion.Text;

        // Validar los datos ingresados
        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(correo) ||
            string.IsNullOrWhiteSpace(telefono) ||
            string.IsNullOrWhiteSpace(direccion))
        {
            DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }
        ClientesClase nuevoCliente = new ClientesClase
        {
            
            NombreCli = entryNombre.Text,
            ApellidoCli = entryApellido.Text,
            CorreoElectronicoCli = entryCorreo.Text,
            NumeroTelefonoCli = entryTelefono.Text,
            FechaRegistroCli = DateTime.Now, 
            Direccion = entryDireccion.Text


        };

        
        List<ClientesClase> listaClientes = new List<ClientesClase>();

        if (Preferences.ContainsKey("Clientes"))
        {
            string clientesString = Preferences.Get("Clientes", string.Empty);
            listaClientes = JsonSerializer.Deserialize<List<ClientesClase>>(clientesString);
        }

        listaClientes.Add(nuevoCliente);

        var serializedClientes = JsonSerializer.Serialize(listaClientes);
        Preferences.Set("Clientes", serializedClientes);

        DisplayAlert("Éxito", "Cliente guardado correctamente", "OK");

        entryNombre.Text = string.Empty;
        entryApellido.Text = string.Empty;
        entryCorreo.Text = string.Empty;
        entryTelefono.Text = string.Empty;
        entryDireccion.Text = string.Empty;
    }
}