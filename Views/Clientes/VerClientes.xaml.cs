using ProyectoP2.Models;
using System;
using System.Collections.Generic;


namespace ProyectoP2
{
    public partial class VerClientes : ContentPage
    {
        public VerClientes()
        {
            InitializeComponent();

            if (Preferences.ContainsKey("Clientes"))
            {
                string clientesString = Preferences.Get("Clientes", string.Empty);
                List<ClientesClase> clientesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<ClientesClase>>(clientesString);
                listViewClientes.ItemsSource = clientesGuardados;
                BindingContext = this;
            }
        }

        private async void EliminarClienteClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is ClientesClase cliente)
            {
                bool answer = await DisplayAlert("Confirmar", "�Est� seguro de que desea eliminar este cliente?", "S�", "No");

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

        private async void DetalleClienteClicked(object sender, EventArgs e)
        {
            var clienteSeleccionado = (ClientesClase)((Button)sender).CommandParameter;

            // Redirigir a la p�gina DetalleCliente pasando el cliente seleccionado como par�metro
            await Navigation.PushAsync(new DetalleCliente(clienteSeleccionado));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Actualizar la lista de clientes cada vez que la p�gina se muestre
            if (Preferences.ContainsKey("Clientes"))
            {
                string clientesString = Preferences.Get("Clientes", string.Empty);
                List<ClientesClase> clientesGuardados = System.Text.Json.JsonSerializer.Deserialize<List<ClientesClase>>(clientesString);
                listViewClientes.ItemsSource = null; // Limpiar la lista existente
                listViewClientes.ItemsSource = clientesGuardados;
                BindingContext = this;
            }
        }
    }
}
