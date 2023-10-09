﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        new Command(async () =>
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
     });

    }
}
