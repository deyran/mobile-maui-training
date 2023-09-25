using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using MauiAPI.APIEln;

namespace MauiAPI
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiElnData _apiElnData;
        public List<ExtintorData> extintorData { set; get; }

        public MainPage()
        {
            _apiElnData = new ApiElnData();
            InitializeComponent();
            InitializeComp();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            extintorData = await _apiElnData.GetItemsAsync();
            BindingContext = this;
        }

        private void InitializeComp()
        {
            Title = "Lista de Extintores";
            Content = new CollectionView
            {
                ItemsSource = "{Binding ExtintorData}",
                ItemTemplate = new DataTemplate(() =>
                {
                    var id = new Label { Text = "{Binding ExtintorAlmoxarifadoID}" };
                    var descLabel = new Label { Text = "{Binding Descricao}" };
                    var ufLabel = new Label { Text = "{Binding Uf}" };
                    var ExtFisLabel = new Label { Text = "{Binding ExtintorFisicos}" };

                    return new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { id, descLabel, ufLabel, ExtFisLabel }
                    };
                })
            };
        }
    }
}