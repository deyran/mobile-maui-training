
using SQLite;

namespace OficinaApp.Data
{
    public class SQLiteData
    {
        readonly SQLiteAsyncConnection _conexaoDB;
        public UsuarioData UsuarioDataTable { get; set; }
    }
}
