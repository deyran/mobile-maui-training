# Curso Maui .Net

## [Curso Maui .Net - Navegando para página de Cadastro - Parte 5 - Crud com Maui + Sqlite](https://youtu.be/II90YWU2dKU?si=WVJkUh33OUmYvx8K)

### Update classe Usuario

```
public Usuario()
{
    Id = Guid.NewGuid();
}
```

### Injeção de dependência

1. Abrir o arquivo **App.xaml.cs**
2. Faça a seguinte edição

```
...
static SQLiteData _bancoDados;

public static SQLiteData BancoDados
{
    get
    {
        if(_bancoDados == null)
        {
            _bancoDados =
                new SQLiteData (
                    DependencyService
                        .Get<ISQLiteDB>()
                        .SQLiteLocalPath("Dados.db3"));
        }

        return _bancoDados;
    }
}

...

public App {...}
...
```

3. [03:00](https://youtu.be/II90YWU2dKU?t=185) Ainda no arquivo **App.xaml.cs**, crie usuário estatico

```
...
public static SQLiteData BancoDados {...}

public static Usuario Usuario { get; set; }

public App {...}
...
```

4. [04:15](https://youtu.be/II90YWU2dKU?t=257) Atualizar o construtor da classe **SQLiteData**

```
..
public SQLiteData(...)
{
    ...
    UsuarioDataTable = new UsuarioData(_conexaoDB);
}
...
```

5. [05:15](https://youtu.be/II90YWU2dKU?t=316) Atualizar a classe **EditaUsuarioPage.xaml.cs**

```
...
Usuario _usuario;

public EditaUsuarioPage()
{
    ...
    _usuario = new Usuario();
    this.BindingContext = _usuario;
}

private void btnCadastrar_Cliked(object sender, EventArgs e)
{
    if(string.IsNullOrWhiteSpace(_usuario.email) &&
       string.IsNullOrWhiteSpace(_usuario.senha))
    {
        await DisplayAlert("Atenção", "Preencha todas as informações", "Fechar");
        return;
    }

    var cadastro = await App.BancoDados.UsuarioDataTable.SalvarUsuario(_usuario);

    if(cadastro > 0)
    {
        await Navigation.PopAsync();
    }
}
...
```

6. [09:00](https://youtu.be/II90YWU2dKU?t=551) Adicionar o botão "Voltar" do arquivo **EditaUsuarioPage.xaml**

```
<Button 
    Text="Voltar" 
    x:Name="btnVoltar" 
    Clicked="btnVoltar_Cliked"
    Margin="10" />
```

7. [09:38](https://youtu.be/II90YWU2dKU?t=578) Implementar o método "Voltar" na classe **EditaUsuarioPage.xaml.cs**

```
...
private void btnVoltar_Cliked(object sender, EventArgs e)
{
    await Navigation.PopAsync();
}
...
```

8. [10:00](https://youtu.be/II90YWU2dKU?t=610) Tirar navegação superior

9. [15:00](https://youtu.be/II90YWU2dKU?t=933) Configuração da plataforma

1. Na raiz do projeto criar uma classe statica chamada "Constantes.cs"

```
public static class Constantes
{
    private const string DBFileName = "Dados.db3";

    public const SQLiteOpenFlags Flags = 
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCashe;
}
```

2. AAAA

[Parte 6](curso-maui-net-p6.md)

<!--
# Curso Maui .Net
## Curso Maui .Net - Navegando para página de Cadastro - Parte 5 - Crud com Maui + Sqlite
### Configuração da plataforma
#### Classe Constantes
-->