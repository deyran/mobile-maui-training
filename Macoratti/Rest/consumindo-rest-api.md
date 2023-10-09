# [Consumindo serviços REST](https://youtu.be/waUne0fOz3s?si=9hkHJAkDZ7zEAvQj)

## [00:13 - Introdução](https://youtu.be/waUne0fOz3s?t=13)

## [10:00 - Construindo app Maui](https://youtu.be/waUne0fOz3s?t=607)

* Nome da App -> MauiApiRest

## [11:17 - Definindo modelo de domínio](https://youtu.be/waUne0fOz3s?t=677)

1. Na raiz criar pasta **Models**
2. Implementar a classe **Categoria** na pasta Models
```
public class Categoria
{
    public int CategoriaId { get; set; }
    public string Nome { get; set; }
    public string ImagemUrl { get; set; }
}
```

## [13:42 - Atualizar o arquivo **MainPage.xaml**](https://youtu.be/waUne0fOz3s?t=822)

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MauiApiRest.MainPage">

    <ScrollView>
        <VerticalStackLayout Padding="5">
            <Entry Placeholder="Categoria Id" Text="{Binding CategoriaInfoId}"/>
            <Entry Placeholder="Categoria Nome" Text="{Binding CategoriaInfoNome}"/>

            <StackLayout Orientation="Horizontal" Spacing="10" HorizontalOptions="Center">
                <Button  Text="Load" Command="{Binding GetCategoriasCommand}" />
                <Button  Text="Get" Command="{Binding GetCategoriaCommand}"/>
                <Button  Text="Add" Command="{Binding AddCategoriaCommand}" />
                <Button  Text="Update" Command="{Binding UpdateCategoriaCommand}"/>
                <Button  Text="Remove" Command="{Binding DeleteCategoriaCommand}"/>
                
            </StackLayout>

            <CollectionView x:Name="ColView1" ItemsSource="{Binding Categorias}"
                              EmptyView="Nenhum item encontrado">
                
                <CollectionView.ItemsLayout>
                    <GridItemsLayout Orientation="Vertical" Span="2"/>
                </CollectionView.ItemsLayout>
                
                <CollectionView.ItemTemplate>
                    <DataTemplate>
                        <VerticalStackLayout Padding="5">
                            <Frame CornerRadius="10" HasShadow="True" 
                                                   Padding="2">
                                <Grid Padding="5" ColumnSpacing="0" 
                                                RowSpacing="0" 
                                                Margin="2">
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="Auto"/>
                                        <RowDefinition Height="180"/>
                                        <RowDefinition Height="Auto"/>
                                    </Grid.RowDefinitions>
                                    <Label Grid.Row="0" Text ="{Binding CategoriaId}"  
                                                       HorizontalOptions="End"/>
                                    <Image Grid.Row="1" Source="{Binding ImagemUrl}"
                                                      Aspect="AspectFit"/>
                                    <Label Grid.Row="2" Text="{Binding Nome}" 
                                                      TextColor="Magenta"
                                                      HorizontalTextAlignment="Center" />
                                </Grid>
                            </Frame>
                        </VerticalStackLayout>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>
        </VerticalStackLayout>
    </ScrollView>

</ContentPage>
```

## [17:29 - Configuração da implementação do padrão MVVM](https://youtu.be/waUne0fOz3s?t=1049)

1. Instalar o pacote **Community.ToolKit.Mvvm**
2. Criar a pasta **ViewsModels**
3.  Criar a classe parcial **MainViewModel**
```
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

    }
}
```

## [19:11 - Coleção de categoria - **GetAsync**](https://youtu.be/waUne0fOz3s?t=1151)

```
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
```

## [21:25 - Atualizar o arquivo **MainPage.xaml.cs**](hhttps://youtu.be/waUne0fOz3s?t=1285)

```
using MauiApiRest.ViewsModels;

namespace MauiApiRest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
```

## [20:27 - GetAsync - Lista](https://youtu.be/waUne0fOz3s?t=1227)

```
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
```

## [23:36 - GetAsync - um item](https://youtu.be/waUne0fOz3s?t=1416)

```
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

```

## [26:03 - PostAsync - Add um item](https://youtu.be/waUne0fOz3s?t=1563)

```
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
```

## [29:12 - PutAsync - Atualiza um item](https://youtu.be/waUne0fOz3s?t=1752)

```
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
        await CarregaCategoriasAsync(); // Atualiza a lista de produtos
    }
});
```

<!--
# Consumindo serviços REST
## 00:13 - Introdução
## 10:00 - Construindo app Maui
## 11:17 - Definindo modelo de domínio
## 13:42 - Atualizar o arquivo **MainPage.xaml**
## 17:29 - Configuração da implementação do padrão MVVM
## 19:11 - Coleção de categoria - **GetAsync**
## 21:25 - Atualizar o arquivo **MainPage.xaml.cs**
## 20:27 - GetAsync - Lista
## 23:36 - GetAsync - um item
## 29:12 - PutAsync - Atualiza um item
-->