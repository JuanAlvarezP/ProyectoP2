using ProyectoP2.Models;
using System.Text.Json;

namespace ProyectoP2;

public partial class RegistrarClientes : ContentPage
{
    private List<ClientesClase> clientes;

    public RegistrarClientes()
    {
        InitializeComponent();

        // Obtener clientes guardados (si los hay)
        clientes = ObtenerClientesGuardados();
    }

    // Método para obtener los clientes guardados
    private List<ClientesClase> ObtenerClientesGuardados()
    {
        List<ClientesClase> clientesGuardados = new List<ClientesClase>();

        // Lógica para recuperar los clientes de tu fuente de datos (por ejemplo, base de datos o almacenamiento local)
        // Ejemplo de código para obtener clientes desde una fuente de datos:

        // clientesGuardados = ObtenerClientesDesdeFuenteDeDatos();

        return clientesGuardados;
    }

    // Método para guardar un nuevo cliente
    private void GuardarClienteClicked(object sender, EventArgs e)
    {
        // Aquí debes obtener los datos del cliente del formulario y crear una nueva instancia de ClientesClase
        ClientesClase nuevoCliente = new ClientesClase
        {
            // Asignar los valores desde tu formulario
            // Por ejemplo:
            NombreCli = entryNombre.Text,
            ApellidoCli = entryApellido.Text,
            CorreoElectronicoCli = entryCorreo.Text,
            NumeroTelefonoCli= entryTelefono.Text
            // ... otros campos
        };

        // Agregar el nuevo cliente a la lista local
        clientes.Add(nuevoCliente);

        // Guardar los clientes actualizados en tu fuente de datos (base de datos, almacenamiento local, etc.)
        // Por ejemplo:
        // GuardarClientesEnFuenteDeDatos(clientes);

        // Una vez guardado el cliente, podrías mostrar un mensaje de éxito o navegar a otra página
        DisplayAlert("Éxito", "El cliente se ha registrado correctamente", "Aceptar");

        // Limpiar los campos del formulario después de guardar el cliente
        LimpiarCampos();
    }

    // Método para limpiar los campos del formulario después de guardar el cliente
    private void LimpiarCampos()
    {
        entryNombre.Text = string.Empty;
        entryApellido.Text = string.Empty;
        entryCorreo.Text = string.Empty;
        entryTelefono.Text = string.Empty;
        // Limpiar otros campos si es necesario
    }
}