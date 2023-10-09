using CommunityToolkit.Mvvm.ComponentModel;
using MauiApiRest.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace MauiApiRest.ViewsModels
{
    public partial class MainViewModel : ObservableObject
    {
        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://catalogo.macoratti.net/api/1";

        [ObservableProperty]
        public string _categoriaInfoId;
        [ObservableProperty]
        public string _categoriaInfoNome;
        [ObservableProperty]
        public Categoria _categoria;
        [ObservableProperty]
        public ObservableCollection<Categoria> _categorias;
        [ObservableProperty]
        private string _nome;
        [ObservableProperty]
        private string _imagemUrl;

        public MainViewModel()
        {
            client = new HttpClient();
            Categorias = new ObservableCollection<Categoria>();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // GetAsync - Lista
        //retornar a coleção de categorias
        public ICommand GetCategoriasCommand =>
           new Command(async () => await CarregaCategoriasAsync());
        private async Task CarregaCategoriasAsync()
        {
            var url = $"{baseUrl}/categorias";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ObservableCollection<Categoria>>(responseStream, _serializerOptions);
                    Categorias = data;
                }
            }
        }

        // GetAsync - Específico
        public ICommand GetCategoriaCommand =>
            new Command(async() => CarregaCategoriaAsync());
        private async Task CarregaCategoriaAsync()
        {
            if (CategoriaInfoId is not null)
            {
                var categoriaId = Convert.ToInt32(CategoriaInfoId);
                if (categoriaId > 0)
                {
                    var url = $"{baseUrl}/categorias/{categoriaId}";
                    var response = await client.GetAsync(url);

                    Categorias.Clear();

                    if (response.IsSuccessStatusCode)
                    {
                        using (var responseStream =
                                await response.Content.ReadAsStreamAsync())
                        {
                            var data = await JsonSerializer
                            .DeserializeAsync<Categoria>(responseStream, _serializerOptions);
                            Categoria = data;
                        }

                        Categorias.Add(Categoria);
                    }
                }
            }
        }

        // PostAsync - add
        public ICommand AddCategoriaCommand =>
        new Command(async () =>
        {
            var url = $"{baseUrl}/categorias";

            if (CategoriaInfoNome is not null)
            {
                var categoria =
                    new Categoria
                    {
                        Nome = CategoriaInfoNome,
                        ImagemUrl = "https://www.macoratti.net/Imagens/lanches/pudim1.jpg"
                    };
                string json = JsonSerializer.Serialize<Categoria>(categoria, _serializerOptions);

                StringContent content =
                    new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                await CarregaCategoriasAsync();
            }
        });

        // PutAsync - Update
        public ICommand UpdateCategoriaCommand =>
        new Command(async () =>
        {
            if (CategoriaInfoId is not null && CategoriaInfoNome is not null)
            {
                var categoriaId = Convert.ToInt32(CategoriaInfoId);
                var categoria = Categorias.FirstOrDefault(x => x.CategoriaId == categoriaId);

                var url = $"{baseUrl}/categorias/{categoriaId}";
                categoria.Nome = CategoriaInfoNome;

                string jsonResponse = JsonSerializer.Serialize<Categoria>(categoria, _serializerOptions);

                StringContent content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                await CarregaCategoriaAsync(); // Carrega o item atualizado
            }
        });
    }
}
