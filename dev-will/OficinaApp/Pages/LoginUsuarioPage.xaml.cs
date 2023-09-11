namespace OficinaApp.Pages;

public partial class LoginUsuarioPage : ContentPage
{
	public LoginUsuarioPage()
	{
		InitializeComponent();
	}
    
    private void BtnEntrar_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnRegistrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditaUsuarioPage());
    }
}