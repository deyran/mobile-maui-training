using SQLite;

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
            OperacoesVSL.IsVisible = true;

            ListarSites();
        }

        private void InserirBtn_Clicked(object sender, EventArgs e)
        {
            Site site;
            site = new Site();

            site.Endereco = ValorEnt.Text;
            _conn.Insert(site);

            LimparCampos();
            ListarSites();
        }

        private void AlterarBtn_Clicked(object sender, EventArgs e)
        {
            Site site;
            site = new Site();

            site.Id = int.Parse(IdEnt.Text);
            site.Endereco = ValorEnt.Text;

            _conn.Update(site);

            LimparCampos();
            ListarSites();
        }

        private void ExcluirBtn_Clicked(object sender, EventArgs e)
        {
            Site site;
            site = new Site();

            site.Id = int.Parse(IdEnt.Text);
            _conn.Delete(site);

            LimparCampos();
            ListarSites();
        }

        private void ListarBtn_Clicked(object sender, EventArgs e)
        {
            LimparCampos();
            ListarSites();
        }

        public void ListarSites()
        {
            List<Site> lista = _conn.Table<Site>().ToList();
            ListaCv.ItemsSource = lista;

        }

        public void LimparCampos()
        {
            ValorEnt.Text = "";
            IdEnt.Text = "";
        }
    }
}