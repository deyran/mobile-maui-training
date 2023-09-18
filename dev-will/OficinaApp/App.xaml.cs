using OficinaApp.Model;
using OficinaApp.Data;
using OficinaApp.Pages;

namespace OficinaApp
{
    public partial class App : Application
    {
        static SQLiteData _bancoDados;

        public static SQLiteData BancoDados
        {
            get 
            { 
                if( _bancoDados == null )
                {
                    _bancoDados =
                        new SQLiteData
                        (
                            DependencyService
                                .Get<ISQLiteDB>()
                                .SQLiteLocalPath("Dados.db3")
                        );
                }

                return _bancoDados; 
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginUsuarioPage());                
        }

        public static Usuario Usuario { get; set; }
    }
}