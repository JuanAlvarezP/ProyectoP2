using ProyectoP2.Models;
using System.Text.Json;
using System.Windows.Input;

namespace ProyectoP2;

public partial class VerClientes : ContentPage
{
    public ICommand DeleteCommand { get; }

    public VerClientes()
    {
        InitializeComponent();

        if (Preferences.ContainsKey("Clientes"))
        {
            string clientesString = Preferences.Get("Clientes", string.Empty);
            List<ClientesClase> clientesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<ClientesClase>>(clientesString);

            listViewClientes.ItemsSource = clientesGuardados;
        }

        DeleteCommand = new Command<ClientesClase>(async (cliente) => await EliminarCliente(cliente));
        BindingContext = this;
    }

    private async Task EliminarCliente(ClientesClase cliente)
    {
        bool answer = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar este cliente?", "Sí", "No");

        if (answer)
        {
            if (listViewClientes.ItemsSource is IList<ClientesClase> clientes)
            {
                clientes.Remove(cliente);

                var serializedClientes = System.Text.Json.JsonSerializer.Serialize(clientes);
                Preferences.Set("Clientes", serializedClientes);

                listViewClientes.ItemsSource = null;
                listViewClientes.ItemsSource = clientes;
            }
        }
    }
}