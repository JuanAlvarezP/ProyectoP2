namespace ProyectoP2;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
	}

    private async void botonEntrar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}