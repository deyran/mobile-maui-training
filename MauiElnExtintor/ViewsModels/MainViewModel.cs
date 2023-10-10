using CommunityToolkit.Mvvm.ComponentModel;
using MauiElnExtintor.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace MauiElnExtintor.ViewsModels
{
    public partial class MainViewModel : ObservableObject
    {
        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://sgestorweb.eletronorte.com.br/engenharia/segtrabalho/api";

        [ObservableProperty]
        public string _extintorAlmInfoId;
        [ObservableProperty]
        public string _extintorAlmInfoDesc;
        [ObservableProperty]
        public ExtintorAlmoxarifado _extintorAlmoxarifado;
        [ObservableProperty]
        public ObservableCollection<ExtintorAlmoxarifado> _extintorAlmoxarifados;
        [ObservableProperty]
        private string _descricao;
        [ObservableProperty]
        private string _uf;
        [ObservableProperty]
        private string _extintorFisico;

        public MainViewModel()
        {
            client = new HttpClient();
            ExtintorAlmoxarifados = new ObservableCollection<ExtintorAlmoxarifado>();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        //GET - Load list
        public ICommand GetExtintorAlmoxarifadosCommand =>
        new Command(async () => await LoadExtintorAlmoxarifadosAsync());
        private async Task LoadExtintorAlmoxarifadosAsync()
        {
            var url = $"{baseUrl}/extintoralmoxarifados";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode) 
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ObservableCollection<ExtintorAlmoxarifado>>(responseStream, _serializerOptions);
                    ExtintorAlmoxarifados = data;
                }
            }
        }

    }
}
