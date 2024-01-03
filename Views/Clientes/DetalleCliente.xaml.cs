using ProyectoP2.Models;
using System;


namespace ProyectoP2
{
    public partial class DetalleCliente : ContentPage
    {
        private ClientesClase cliente;

        public DetalleCliente(ClientesClase cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            BindingContext = this.cliente;
        }

        private async void ActualizarClienteClicked(object sender, EventArgs e)
        {
            // Aquí obtienes los nuevos datos ingresados por el usuario y actualizas el cliente existente
            cliente.NombreCli = NombreEntry.Text;
            cliente.ApellidoCli = ApellidoEntry.Text;
            cliente.CorreoElectronicoCli = CorreoElectronicoEntry.Text;
            cliente.NumeroTelefonoCli = NumeroTelefonoEntry.Text;
            cliente.Direccion = DireccionEntry.Text;

            // Guarda los datos actualizados en Preferencias
            if (Preferences.ContainsKey("Clientes"))
            {
                string clientesString = Preferences.Get("Clientes", string.Empty);
                var clientesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<ClientesClase>>(clientesString);

                // Encuentra y actualiza el cliente en la lista
                var clienteAActualizar = clientesGuardados.Find(c => c.Id == cliente.Id);
                if (clienteAActualizar != null)
                {
                    clienteAActualizar.NombreCli = cliente.NombreCli;
                    clienteAActualizar.ApellidoCli = cliente.ApellidoCli;
                    clienteAActualizar.CorreoElectronicoCli = cliente.CorreoElectronicoCli;
                    clienteAActualizar.NumeroTelefonoCli = cliente.NumeroTelefonoCli;
                    clienteAActualizar.Direccion = cliente.Direccion;

                    var serializedClientes = System.Text.Json.JsonSerializer.Serialize(clientesGuardados);
                    Preferences.Set("Clientes", serializedClientes);
                }
            }

            await DisplayAlert("Éxito", "El cliente se actualizó correctamente", "OK");

            // Regresa a la página anterior (VerClientes)
            await Navigation.PopAsync();
        }
    }
}
