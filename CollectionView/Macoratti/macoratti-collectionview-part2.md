# [.NET MAUI : Apresentando CollectionView - II](https://www.youtube.com/watch?v=687RtN7NrQk)

## ItemsLayout - Definindo layout no CollectionView

* Existem dois tipos de layouts no CollectionView:

1. Listas (VerticalList, HorizontalList) - Listas com colunas ou linhas únicas
2. Grades (VerticalGrid, HorizontalGrid) - Grades com colunas ou linhas

* Os layouts no CollectionView são implementados da seguinte forma:
  
1. Na propriedade **ItemsLayout** da CollectionView, como mostrado no código seguinte:
   
```
<CollectionView ItemsSourcer="{Binding Produtos}"
                ItemsLayout="HorizontalList">
    ...
</CollectionView>
```

2. Customizável, como mostrado no código seguinte:

```
<CollectionView ItemsSourcer="{Binding Produtos}">
    ...

    <CollectionView.ItemsLayout>
	    <LinearItemsLayout Orientation="Horizontal" />	
    </CollectionView.ItemsLayout>

    ....

    <CollectionView.ItemsLayout>
	    <GridItemsLayout Orientation="Vertical" />	
    </CollectionView.ItemsLayout>

    ...
</CollectionView>
```

### Exemplo prático

1. Abra o projeto **MauiCollectionView**, na pasta **Views**, criar o arquivo **LayoutView.xaml**
2. No arquivo **LayoutView.xaml.cs**, crie uma instancia do classe **ProdutoViewModel** para a propriedade **BindingContext**, como mostrado no código a seguir:

```
using MauiCollectionView.MVVM.ViewModels;

namespace MauiCollectionView.MVVM.Views;

public partial class LayoutView : ContentPage
{
	public LayoutView()
	{
		InitializeComponent();
		BindingContext = new ProdutoViewModel();
	}
}
```

3. Edite o arquivo **LayoutView.xaml** da seguinte forma:

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MauiCollectionView.MVVM.Views.LayoutView"
             Title="LayoutView">

    <CollectionView ItemsSource="{Binding Produtos}">
        <CollectionView.ItemTemplate>
            <DataTemplate>
                <Frame  Margin="15" HeightRequest="250" WidthRequest="180">
                    <VerticalStackLayout>
                        <Image Source="{Binding Imagem}" />
                        <Label HorizontalTextAlignment="Center" Text="{Binding Nome}" />
                    </VerticalStackLayout>
                </Frame>
            </DataTemplate>
        </CollectionView.ItemTemplate>
    </CollectionView>
    
</ContentPage>
```

4. Edite o arquivo *App.xaml.cs*, de **MainPage = new ProdutoView();** para **MainPage = new LayoutView();**
   
5. Rode a aplicação e veja o seguinte resultado:

    <p align="center"><img src="img05.png" /></p>
   
6. Como pode ser visto a propriedade **ItemsLayout** do **CollectionView** foi omitida. Isso porque o valor padrão é **ItemsLayout="VerticalList"**. 
   
7. Atribua o valor **HorizontalList** e você terá o seguinte resultado:
   
    <p align="center"><img src="img06.png" /></p>

8. AAAA
9.  AAA

## XXXX

<!--
# .NET MAUI : Apresentando CollectionView - II
## ItemsLayout - Definindo layout no CollectionView
### Exemplo prático

-----------------------
# .NET MAUI : Apresentando CollectionView - II
## ItemsLayout - Definindo layout no CollectionView
### Propriedade ItemsLayout
### Exemplo prático
-->