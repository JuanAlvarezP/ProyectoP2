namespace ProyectoP2;

public partial class Citas : ContentPage
{
	public Citas()
	{
		InitializeComponent();
	}

    private async void botonRegistrarCitas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrarCitas());

    }

    private async void botonVerCitas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerCitas());
    }
}