using ProyectoP2.Models;
using System.Text.Json;

namespace ProyectoP2;

public partial class VerClientes : ContentPage
{
    private List<ClientesClase> clientes;

    public VerClientes()
    {
        InitializeComponent();

        // Obtener clientes guardados (si los hay)
        clientes = ObtenerClientesGuardados();

        // Mostrar solo clientes guardados al inicializar la p�gina
        MostrarClientesGuardados();
    }

    // M�todo para obtener los clientes guardados
    private List<ClientesClase> ObtenerClientesGuardados()
    {
        List<ClientesClase> clientesGuardados = new List<ClientesClase>();

        // L�gica para recuperar los clientes de tu fuente de datos, por ejemplo, desde la base de datos o almacenamiento local

        return clientesGuardados;
    }

    // M�todo para mostrar los clientes guardados en el ListView
    private void MostrarClientesGuardados()
    {
        listViewClientes.ItemsSource = clientes;
    }

    // M�todo para registrar un nuevo cliente
    private async void RegistrarClienteClicked(object sender, EventArgs e)
    {
        // Aqu� debes implementar la l�gica para registrar un nuevo cliente
        // Por ejemplo, navegar a la p�gina de registro de clientes
        await Navigation.PushAsync(new RegistrarClientes());
    }

    // M�todo para eliminar un cliente
    private async void EliminarClienteClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is ClientesClase cliente)
        {
            // Aqu� debes implementar la l�gica para eliminar un cliente
            // Por ejemplo, eliminar el cliente de la lista y actualizar la interfaz
            clientes.Remove(cliente);
            MostrarClientesGuardados();

            // Tambi�n deber�as actualizar la fuente de datos persistente (base de datos, almacenamiento local, etc.)
            // Para guardar los cambios en los clientes
        }
    }
}