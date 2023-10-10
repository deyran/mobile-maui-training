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
        private string _extintorAlmInfoUf;//_uf;
        [ObservableProperty]
        private string _extintorAlmInfoFisico;// _extintorFisico;

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
            var url = $"{baseUrl}/extintoralmoxarifados/";
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

        //GET - |Get an item
        public ICommand GetExtintorAlmoxarifadoCommand =>
            new Command(async () => await LoadExtintorAlmoxarifadoCommand());
        private async Task LoadExtintorAlmoxarifadoCommand()
        {
            if (ExtintorAlmInfoId is not null)
            {
                var extintorAlmInfoId = Convert.ToInt32(ExtintorAlmInfoId);

                if (extintorAlmInfoId > 0)
                {
                    var url = $"{baseUrl}/extintoralmoxarifados/{extintorAlmInfoId}";
                    var response = await client.GetAsync(url);

                    ExtintorAlmoxarifados.Clear();

                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            var data = await JsonSerializer
                            .DeserializeAsync<ExtintorAlmoxarifado>(responseStream, _serializerOptions);
                            ExtintorAlmoxarifado = data;
                        }

                        ExtintorAlmInfoId = Convert.ToString(ExtintorAlmoxarifado.ExtintorAlmoxarifadoID);
                        ExtintorAlmInfoDesc = ExtintorAlmoxarifado.Descricao;
                        ExtintorAlmInfoUf = ExtintorAlmoxarifado.Uf;
                        ExtintorAlmInfoFisico = ExtintorAlmoxarifado.ExtintorFisico;

                        ExtintorAlmoxarifados.Add(ExtintorAlmoxarifado);

                    }
                }
            }
        }

        //Post - add an item
        public ICommand AddExtintorAlmoxarifadoCommand =>
        new Command(
            async () =>
            {
                if (ExtintorAlmInfoDesc is not null)
                {
                    var url = $"{baseUrl}/extintoralmoxarifados";

                    var extintorAlmoxarifado = new ExtintorAlmoxarifado();
                    extintorAlmoxarifado.Descricao = ExtintorAlmInfoDesc;
                    extintorAlmoxarifado.Uf = ExtintorAlmInfoUf;
                    extintorAlmoxarifado.ExtintorFisico = ExtintorAlmInfoFisico;

                    string json =
                        JsonSerializer.Serialize<ExtintorAlmoxarifado>(extintorAlmoxarifado, _serializerOptions);

                    StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);
                    await LoadExtintorAlmoxarifadosAsync();
                }
            }
        );

        //Put - Update an item
        public ICommand UpdateExtintorAlmoxarifadoCommand =>
            new Command(async () => PutExtintorAlmoxarifado());
        private async Task PutExtintorAlmoxarifado()
        {
            if (ExtintorAlmInfoId is not null && ExtintorAlmInfoDesc is not null)
            {
                var extintorAlmInfoId = Convert.ToInt32(ExtintorAlmInfoId);
                var extintorAlmoxarifado = ExtintorAlmoxarifados
                    .FirstOrDefault(x => x.ExtintorAlmoxarifadoID == extintorAlmInfoId);

                var url = $"{baseUrl}/extintoralmoxarifados/{extintorAlmInfoId}";

                extintorAlmoxarifado.Descricao = ExtintorAlmInfoDesc;
                extintorAlmoxarifado.Uf = ExtintorAlmInfoUf;
                extintorAlmoxarifado.ExtintorFisico = ExtintorAlmInfoFisico;

                string jsonResponse = JsonSerializer
                    .Serialize<ExtintorAlmoxarifado>(extintorAlmoxarifado, _serializerOptions);

                StringContent content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                await LoadExtintorAlmoxarifadoCommand();
            }
        }

        //Delete - Delete an item
        public ICommand DeleteExtintorAlmoxarifadoCommand =>
            new Command(async () => DeleteExtintorAlmoxarifado());
        private async Task DeleteExtintorAlmoxarifado()
        {
            if (ExtintorAlmInfoId is not null)
            {
                var extintorAlmInfoId = Convert.ToInt32(ExtintorAlmInfoId);
                if (extintorAlmInfoId > 0)
                {
                    var url = $"{baseUrl}/extintoralmoxarifados/{extintorAlmInfoId}";
                    var response = await client.DeleteAsync(url);
                    await LoadExtintorAlmoxarifadosAsync();

                    ExtintorAlmInfoId = null;
                }
            }
        }
    }
}
