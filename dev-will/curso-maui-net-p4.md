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
                .FirstOrDefaultAsync();

            return usuario;
        }

        public Task<Usuario> ObtemUsuario(Guid id)
        {
            var usuario = _conexaoDB
                .Table<Usuario>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<int> SalvarUsuario(Usuario usuario)
        {
            var usuarioIsSalvo = await ObtemUsuario(usuario.Id);

            if(usuarioIsSalvo == null)
            {
                return await _conexaoDB.InsertAsync(usuario);
            }
            else
            {
                return await _conexaoDB.UpdateAsync(usuario);
            }
        }

        public async Task<int> ExcluiUsuario(Guid id)
        {
            return await _conexaoDB.DeleteAsync(id);
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

[Parte 5](curso-maui-net-p5.md)

<!--
# Curso Maui .Net
## Curso Maui .Net - Navegando para página de Cadastro - Parte 4 - Crud com Maui + Sqlite
-->