using OficinaApp.Pages;

namespace OficinaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginUsuarioPage());                
        }
    }
}