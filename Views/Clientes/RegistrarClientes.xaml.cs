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
        ClientesClase nuevoCliente = new ClientesClase
        {
            // Asigna los valores ingresados por el usuario a las propiedades del cliente
            // Aquí asume que tienes los Entry para ingresar los datos del cliente en tu XAML
            NombreCli = entryNombre.Text,
            ApellidoCli = entryApellido.Text,
            CorreoElectronicoCli = entryCorreo.Text,
            NumeroTelefonoCli = entryTelefono.Text,
            FechaRegistroCli = DateTime.Now, // Puedes usar DateTime.Today si no necesitas la hora exacta
            Direccion = entryDireccion.Text
        };

        // Aquí guardas el nuevo cliente en tus datos de clientes, por ejemplo, en una lista
        List<ClientesClase> listaClientes = new List<ClientesClase>();

        if (Preferences.ContainsKey("Clientes"))
        {
            string clientesString = Preferences.Get("Clientes", string.Empty);
            listaClientes = JsonSerializer.Deserialize<List<ClientesClase>>(clientesString);
        }

        listaClientes.Add(nuevoCliente);

        var serializedClientes = JsonSerializer.Serialize(listaClientes);
        Preferences.Set("Clientes", serializedClientes);

        // Muestra un mensaje indicando que el cliente se ha guardado correctamente
        DisplayAlert("Éxito", "Cliente guardado correctamente", "OK");

        // Limpia los campos después de guardar
        entryNombre.Text = string.Empty;
        entryApellido.Text = string.Empty;
        entryCorreo.Text = string.Empty;
        entryTelefono.Text = string.Empty;
        entryDireccion.Text = string.Empty;
    }
}