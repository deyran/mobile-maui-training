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

}

public App
{
    ...
}
...
```

3. AAAA

[Parte 6](curso-maui-net-p6.md)

<!--
# Curso Maui .Net
## Curso Maui .Net - Navegando para página de Cadastro - Parte 5 - Crud com Maui + Sqlite
### Injeção de dependência
-->