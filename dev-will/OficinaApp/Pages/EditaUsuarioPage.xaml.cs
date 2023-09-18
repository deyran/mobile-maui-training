using OficinaApp.Model;

namespace OficinaApp.Pages;

public partial class EditaUsuarioPage : ContentPage
{
    Usuario _usuario;

    public EditaUsuarioPage()
    {
        InitializeComponent();

        _usuario = new Usuario();
        this.BindingContext = _usuario;
    }

    private async void btnCadastrar_Cliked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(_usuario.email) &&
           string.IsNullOrWhiteSpace(_usuario.senha))
        {
            await DisplayAlert("Atenção", "Preencha todas as informações", "Fechar");
            return;
        }

        var cadastro = await App.BancoDados.UsuarioDataTable.SalvarUsuario(_usuario);

        if (cadastro > 0)
        {
            await Navigation.PopAsync();
        }
    }

    private async void btnVoltar_Cliked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}