﻿namespace ProyectoP2;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void botonCitas(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Citas());
	}

	
}

