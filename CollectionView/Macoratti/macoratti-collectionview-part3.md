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

```

<!--
# .NET MAUI : Apresentando CollectionView - III | Agrupando dados
## Exibindo lista de contatos agrupados por ordem alfabética
### Criar classe ContatoViewModel
--------------------------

# .NET MAUI : Apresentando CollectionView - III | Agrupando dados
## Exibindo lista de contatos agrupados por ordem alfabética
### Criar classe Contato
### Criar classe ContatoGroup
### Criar classe ContatoViewModel
-->