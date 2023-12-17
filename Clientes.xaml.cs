namespace ProyectoP2;

public partial class Clientes : ContentPage
{
	public Clientes()
	{
		InitializeComponent();
	}

    private async void botonRegistrarClientes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrarClientes());

    }

    private async void botonVerClientes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerClientes());

    }
}