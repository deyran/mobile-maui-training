# NET MAUI PAGES

## [ContentPage](https://youtu.be/9D42vT3CzO4?list=PLJ4k1IC8GhW3VlYa0p9QhV98Waka7oghq&t=478)

* Exibe uma única View, ou Grid ou ScrollView ou StackLayout
* Representa o conteúdo da página

### Exemplo prático

1. Crie uma ContentPage, chamado **MinhaPagina.xaml**
2. Edite o arquivo **App.Xaml.cs** para definir **MinhaPagina.xaml** como página principal
   
```
namespace MauiDemoPages
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MinhaPagina();
        }
    }
}
```

## [NavigationPage](https://youtu.be/9D42vT3CzO4?list=PLJ4k1IC8GhW3VlYa0p9QhV98Waka7oghq&t=662)

* Permite navegação pelas páginas de forma hieráquica estilo **Pilha** LIFO
* Último a entrar, primeiro ao sair

### Navegação da página

```
await Navigation.PushAsync(new MainPage());
```

### Remover página da pilha de navegação

Ao clicar no botão voltar (<-) ou usar o seguinte método:

```
await Navigation.PopAsync();
```

### Exemplo prático

1. Edite o arquivo **App.xaml.cs** crie a pilha, como mostrado no código seguinte:

```
namespace MauiDemoPages
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MinhaPagina());
        }
    }
}
```

2. Edite o arquivo **MinhaPagina.xaml** da seguinte forma:

```
<Button Text="Navegar para outra Página"
        HorizontalOptions="Center" 
        Clicked="Button_Clicked" />
```

3. Edite o arquivo **MinhaPagina.xaml.cs** da seguinte forma:

```
private async Task Button_ClickedAsync(object sender, EventArgs e)
{
    await Navigation.PushAsync(new MainPage());
}
```

## [FlyoutPage](https://youtu.be/T3HPTy86rU4?list=PLJ4k1IC8GhW3VlYa0p9QhV98Waka7oghq)

* Trata da relação Submenu e detalhes
* Propriedade Title é obrigatória

### Exemplo prático

1. Crie ContentPage (XAML), com nome **FlyoutPageDemo.xaml**

## TabbedPage

<!--
# NET MAUI PAGES
## FlyoutPage
### Exemplo prático

-------------------------
# NET MAUI PAGES
## ContentPage
### Exemplo prático
## NavigationPage
### Navegação da página
### Remover página da pilha de navegação
### Exemplo prático
## FlyoutPage
### Exemplo prático
-->