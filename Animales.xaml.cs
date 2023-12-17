namespace ProyectoP2;

public partial class Animales : ContentPage
{
	public Animales()
	{
		InitializeComponent();
	}

    private async void botonRegistrarAnimales(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrarAnimales());

    }

    private async void botonVerAnimales(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerAnimales());

    }
}