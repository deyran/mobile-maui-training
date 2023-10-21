# [.NET MAUI : Apresentando CollectionView - I](https://youtu.be/-XLblm3LRFk?si=nsvHcXKz43VvI1xF)

## Características do CollectionView

1. Suporta seleção única e múltipla
2. Pode ser vinculado ao uma coleção de dados ou a um modelo de dados personalizado
3. Fornece propriedades e eventos para personalizar aparência e comportamento
4. Usa virtualização, ou seja, somente os itens visiveis são carregados na memória

## Propriedades que definem os dados e sua aparência

1. **ItemsSource** - É um **IEnumerable** que especifica a coleção dados. Tem valor **null** por padrão
   
2. **ItemTemplate** - É um **DataTemplate** que especifica o modelo a ser aplicado a cada item definindo como cada item é exibido. Por exemplo, em uma coleção de dados da classe Pessoa, cada pessoa tem propriedades como Nome, Idade, Sexo, etc. O DataTemplate tem objetos que podem associar-se a cada uma das propriedades da classe Pessoa, definindo assim a forma como elas são exibidas na lista.
   
3. O código abaixo mostra um exemplo de uso da propriedade **ItemsSource**

```
<CollectionView>
    <CollectionView.ItemsSource>
        <x:Array Type="{x:Type x:String}">
            <x:String>Santos</x:String>
            <x:String>Palmeiras</x:String>
            <x:String>Flamengo</x:String>
            <x:String>São Paulo</x:String>
            <x:String>Internacional</x:String>
            <x:String>Atlético-PR</x:String>
        </x:Array>
    </CollectionView.ItemsSource>
</CollectionView>
```

<!--
# .NET MAUI : Apresentando CollectionView - I
## Características do CollectionView
## Propriedades que definem os dados e sua aparência
-->