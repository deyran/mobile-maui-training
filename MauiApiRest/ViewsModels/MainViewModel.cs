using CommunityToolkit.Mvvm.ComponentModel;
using MauiApiRest.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

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
        public string _categoriaInfoName;
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

        // Iniciar o consumo da Api Rest
    }
}
