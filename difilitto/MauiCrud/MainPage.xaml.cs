using SQLite;
using UIKit;

namespace MauiCrud
{
    public partial class MainPage : ContentPage
    {
        string _dbPath;
        SQLite.SQLiteConnection _conn;

        public MainPage()
        {
            InitializeComponent();
        }

        private void CriarBancoDeDadosBtn_Clicked(object sender, EventArgs e)
        {
            _dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "sites.db3");
            _conn = new SQLiteConnection(_dbPath);

            _conn.CreateTable<Site>();
        }

        private void InserirBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void AlterarBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void ExcluirBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void LocalizarBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void ListarBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}