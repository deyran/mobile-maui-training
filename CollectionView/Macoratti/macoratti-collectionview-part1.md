# [.NET MAUI : Apresentando CollectionView - I](https://youtu.be/-XLblm3LRFk?si=nsvHcXKz43VvI1xF)

## Características do CollectionView

1. Suporta seleção única e múltipla
2. Pode ser vinculado ao uma coleção de dados ou a um modelo de dados personalizado
3. Fornece propriedades e eventos para personalizar aparência e comportamento
4. Usa virtualização, ou seja, somente os itens visiveis são carregados na memória

## Propriedades que definem os dados e sua aparência

1. **ItemsSource** - É um **IEnumerable** que especifica a coleção dados. Tem valor **null** por padrão
2. **ItemTemplate** - É um **DataTemplate** que especifica o modelo a ser aplicado a cada item definindo como cada item é exibido. Por exemplo, em uma coleção de dados da classe Pessoa, cada pessoa tem propriedades como Nome, Idade, Sexo, etc. O DataTemplate tem objetos que podem associar-se a cada uma das propriedades da classe Pessoa, definindo assim a forma como elas são exibidas na lista.

<!--
# .NET MAUI : Apresentando CollectionView - I
## Características do CollectionView
## Propriedades que definem os dados e sua aparência
-->