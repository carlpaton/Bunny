using System.Collections.Generic;

namespace Bunny.Repository.Implementation
{
    public interface IBaseContext
    {
        void Open();

        T Select<T>(string sql, object parameters = null) where T : new();
        List<T> SelectList<T>(string sql, object parameters = null);

        int Insert<T>(string sql, object poco);
        void InsertBulk<T>(string sql, object listPoco);

        void Update<T>(string sql, object poco);
        void Delete(string sql, object parameters = null);

        void ExecuteNonQuery(string sql);
    }
}
