# [.NET MAUI : Apresentando CollectionView - III | Agrupando dados](https://youtu.be/pU7gHTFzcCE?si=Tf8FlMlvK2xFkYiI)

## Exibindo lista de contatos agrupados por ordem alfabética

1. Na pasta MVVM/Models crie a classe Contato, mostrado no código abaixo

```
namespace MauiCollectionView.MVVM.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}
```

2. Na pasta MVVM/Models crie a classe ContatoGroup, mostrado no código abaixo

```
namespace MauiCollectionView.MVVM.Models
{
    public class ContatoGroup: List<Contato>
    {
        public string Nome { get; private set; }

        public ContatoGroup(string nome, List<Contato> contatos): base(contatos)
        {
            Nome = nome;
        }
    }
}
```

3. Na pasta MVVM/ViewModels crie a classe ContatoViewModel, mostrado no código abaixo

```
using MauiCollectionView.MVVM.Models;
using System.Collections.ObjectModel;

namespace MauiCollectionView.MVVM.ViewModels
{
    public class ContatoViewModel
    {
        public ObservableCollection<ContatoGroup> ContatosAgrupados { get; set; } =
            new ObservableCollection<ContatoGroup>();

        public ContatoViewModel()
        {
            var contatos = CriarContatos();

            var gruposContato = from p in contatos
                                orderby p.Nome
                                group p by p.Nome[0].ToString()
                                into grupos
                                select new ContatoGroup(grupos.Key, grupos.ToList());


            int id = 1;
            foreach (var group in gruposContato)
            {
                foreach (var contato in group)
                {
                    contato.Id = id;
                    id++;
                }
            }


            ContatosAgrupados = new ObservableCollection<ContatoGroup>(gruposContato.ToList());
        }

        private List<Contato> CriarContatos()
        {
            return new List<Contato>
            {
                new Contato { Nome = "Alex Silveira", Email = "egestas@anequeNullam.co.uk", Telefone="9985-5623" },
                new Contato { Nome = "Wilson Martin", Email = "a.tortor@Sed.net",  Telefone="9985-5623" },
                new Contato { Nome = "Osmar Moss", Email = "tristique@faucibusutnulla.net", Telefone="9985-5623" },
                new Contato { Nome = "Yasmim Dudley", Email = "montes.nascetur.ridiculus@fringillaest.ca", Telefone="9985-5623" },
                new Contato { Nome = "Yoshio Anthony", Email = "ut.aliquam.iaculis@pharetraNam.edu" , Telefone="9985-5623"},
                new Contato { Nome = "Valentina Poole", Email = "auctor@consectetuer.org" , Telefone="9985-5623"},
                new Contato { Nome = "Armando Tillman", Email = "facilisis.vitae.orci@liberolacusvarius.com" , Telefone="9985-5623"},
                new Contato { Nome = "Klaus Hickman", Email = "Pellentesque.habitant@tristiqueaceleifend.org" , Telefone="9985-5623" },
                new Contato { Nome = "Levi Marshall", Email = "imperdiet.ullamcorper@Quisque.com" , Telefone="9985-5623" },
                new Contato { Nome = "Norberto Boone", Email = "adipiscing@anteipsum.ca" , Telefone="9985-5623" },
                new Contato { Nome = "Emerlindo Mendez", Email = "aliquet.molestie.tellus@Nam.net" , Telefone="9985-5623" },
                new Contato { Nome = "Marcos Compton", Email = "Etiam.bibendum.fermentum@malesuadaIntegerid.co.uk" , Telefone="9985-5623" },
                new Contato { Nome = "Braulio Chapman", Email = "lacinia.orci@aliquetdiamSed.ca" , Telefone="9985-5623" },
                new Contato { Nome = "Heleno Roberson", Email = "gravida@Nunc.edu" , Telefone="9985-5623" },
                new Contato { Nome = "Yuri Herrera", Email = "velit@erat.org" , Telefone="9985-5623" },
                new Contato { Nome = "Lucas Brown", Email = "magnis@Cumsociis.org" , Telefone="9985-5623" },
                new Contato { Nome = "Gilson Reilly", Email = "vel@NullamenimSed.com" , Telefone="9985-5623" },
                new Contato { Nome = "Arsenio Suarez", Email = "ridiculus.mus.Aenean@tellusfaucibusleo.co.uk" , Telefone="9985-5623" },
                new Contato { Nome = "Igor Mclaughlin", Email = "ut.lacus.Nulla@Aliquamnec.edu" , Telefone="9985-3023" },
                new Contato { Nome = "Carla Craft", Email = "Etiam.gravida.molestie@rutrummagna.ca" , Telefone="9985-3023" },
                new Contato { Nome = "Benedito Carson", Email = "adipiscing@enimMauris.edu" , Telefone="9985-3023" },
                new Contato { Nome = "Roberto Reynolds", Email = "commodo@sapienmolestie.edu" , Telefone="9985-3023" },
                new Contato { Nome = "Rivaldo Mcguire", Email = "sem.elit.pharetra@nuncrisus.com" , Telefone="9985-3023" },
                new Contato { Nome = "William Fuller", Email = "bibendum@ultrices.com" , Telefone="9985-3023" },
                new Contato { Nome = "Helio Shaffer", Email = "lectus.pede@nisi.org" , Telefone="9985-2123" },
                new Contato { Nome = "Armando Chapman", Email = "erat@Donecsollicitudin.edu" , Telefone="9985-2123" },
                new Contato { Nome = "Josia Adams", Email = "justo.Praesent.luctus@purus.org" , Telefone="9985-2123" },
                new Contato { Nome = "Denis Webb", Email = "sit.amet.consectetuer@Loremipsumdolor.org" , Telefone="9985-2123" },
                new Contato { Nome = "Jacob Singleton", Email = "sem.consequat@vehiculaPellentesque.co.uk" , Telefone="9985-2123" },
                new Contato { Nome = "Carina Tucker", Email = "molestie@erosturpis.ca" , Telefone="9985-2123" },
                new Contato { Nome = "Felix Holder", Email = "sollicitudin.a@Curae.co.uk" , Telefone="9985-1123" },
                new Contato { Nome = "Mateus Reid", Email = "Etiam.bibendum@Donecat.edu" , Telefone="9985-1123" },
                new Contato { Nome = "Anabel Noel", Email = "rhoncus.Donec@vel.edu" , Telefone="9985-1123" },
                new Contato { Nome = "Karina Dunlap", Email = "lectus@risusQuisque.co.uk" , Telefone="9985-1123" },
                new Contato { Nome = "Silvio Ewing", Email = "cubilia@afeugiattellus.ca" , Telefone="9985-1123" },
                new Contato { Nome = "Lucas Reed", Email = "id.risus@Aliquam.edu" , Telefone="9985-1123" },
                new Contato { Nome = "Geraldo Huff", Email = "non.arcu.Vivamus@fames.edu" , Telefone="9985-0923" },
                new Contato { Nome = "Fernando Carroll", Email = "ut.nisi.a@elit.edu" , Telefone="9985-0923" },
                new Contato { Nome = "Leonardo Hamilton", Email = "vitae@penatibusetmagnis.net" , Telefone="9985-0923" },
                new Contato { Nome = "Myles Knowles", Email = "vitae.aliquam@magna.org" , Telefone="9985-0923" },
                new Contato { Nome = "Cristina Schmidt", Email = "imperdiet.dictum.magna@vitaeerat.org" , Telefone="9985-0923" },
                new Contato { Nome = "Thais Ball", Email = "Cras.eu@ataugue.net" , Telefone="9985-0923" },
                new Contato { Nome = "Renato Mclean", Email = "leo@vitaenibh.net" , Telefone="9985-2323" },
                new Contato { Nome = "Celio Rogers", Email = "eros.turpis.non@ettristique.co.uk" , Telefone="9985-1023" },
                new Contato { Nome = "Otavio Estes", Email = "vel@ac.edu" , Telefone="9985-7723"}
            };
        }
    }
}
```

4. Na pasta MVVM/View criar o arquivo **ContatosView.xaml**

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MauiCollectionView.MVVM.Views.ContatosView"
             Title="Contatos">

    <CollectionView ItemsSource="{Binding ContatosAgrupados}"
                    IsGrouped="True">

        <CollectionView.ItemsLayout>
            <LinearItemsLayout ItemSpacing="10" Orientation="Vertical"/>
        </CollectionView.ItemsLayout>

        <CollectionView.ItemTemplate>
            <DataTemplate>
                <VerticalStackLayout Margin="20, 0, 0, 0">
                    <Label Text="{Binding Nome}" FontSize="Large" />
                    <Label Text="{Binding Email}" FontAttributes="Bold" TextColor="Blue" />
                    <Label Text="{Binding Telefone}" FontAttributes="Bold" />
                </VerticalStackLayout>
            </DataTemplate>
        </CollectionView.ItemTemplate>

    </CollectionView>
    
</ContentPage>
```

5. Editar o **BindingContext** do arquivo **ContatosView.xaml.cs**

```
using MauiCollectionView.MVVM.ViewModels;

namespace MauiCollectionView.MVVM.Views;

public partial class ContatosView : ContentPage
{
	public ContatosView()
	{
		InitializeComponent();
		BindingContext = new ContatoViewModel();		
	}
}
```

6. Editar o arquivo **App.xaml.cs**

```
using MauiCollectionView.MVVM.Views;

namespace MauiCollectionView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ContatosView();
        }
    }
}
```

7. Ao rodar a aplicação teremos o seguinte resultado:

<p align="center"><img src="img09.png" /></p>    

<!--
# .NET MAUI : Apresentando CollectionView - III | Agrupando dados
## Exibindo lista de contatos agrupados por ordem alfabética
### Rodar a aplicação
--------------------------

# .NET MAUI : Apresentando CollectionView - III | Agrupando dados
## Exibindo lista de contatos agrupados por ordem alfabética
### Criar classe Contato
### Criar classe ContatoGroup
### Criar classe ContatoViewModel
### Na pasta MVVM/View criar o arquivo ContatosView.xaml
### Editar o BindingContext do arquivo ContatosView.xaml.cs
### Editar o arquivo App.xaml.cs
### Rodar a aplicação
-->