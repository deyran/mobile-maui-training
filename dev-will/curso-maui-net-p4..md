# Curso Maui .Net

## [Curso Maui .Net - Navegando para página de Cadastro - Parte 4 - Crud com Maui + Sqlite](https://youtu.be/Sj0Ew5hiERs?si=ZDAz2cZQxDjVgBdY)

### 00:10 Comunicação com banco de dados

1. [04:00](https://youtu.be/Sj0Ew5hiERs?t=243) Criar a classe **UsuarioData** conforme o código abaixo
   
   ```
    public class UsuarioData
    {
        private SQLiteAsyncConnection _conexaoDB;

        public UsuarioData(SQLiteAsyncConnection conexaoDB)
        {
            _conexaoDB = conexaoDB;
        }

        public Task<List<Usuario>> ListaUsuarios()
        {
            var lista = _conexaoDB
                .Table<Usuario>()
                .ToListAsync();

            retun lista;                
        }

        public Task<Usuario> obtemUsuario(string email, string senha)
        {
            var usuario = _conexaoDB
                .Table<Usuario>()
                .Where(x => x.Email == email && x.Senha == senha)
                .FirstOnDefaultAsync();

            return usuario;
        }
    }
   ```
   
2. Na pasta **Data** criar a seguinte interface
   
   ```
    public interface ISQLiteDB
    {
        string SQLiteLocalPath(string bancoDados);
    }
   ```

3. [2:00](https://youtu.be/Sj0Ew5hiERs?t=119) Na pasta **Data** criar a seguite classe

```
public class SQLiteData
{
    readonly SQLiteAsyncConnection _conexaoBD;
    public usuarioData usuarioDataTable { get; set; }

    public SQLiteData(string path)
    {
        _conexaoBD = new SQLiteAsyncConnection(path);
        _conexaoBD.createTableAsync<usuario>.Wait();
    }
}
```

3. AAAAAA

[Parte 5](curso-maui-net-p4.md)

<!--
# Curso Maui .Net
## Curso Maui .Net - Navegando para página de Cadastro - Parte 4 - Crud com Maui + Sqlite
### 00:10 Comunicação com banco de dados
#### Criar a classe UsuarioData
https://youtu.be/Sj0Ew5hiERs?t=522
-->