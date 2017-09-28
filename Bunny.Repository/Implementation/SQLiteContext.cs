using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Bunny.Repository.Implementation
{
    public class SQLiteContext : IDisposable, IBaseContext
    {
        private readonly SQLiteConnection _dbConn;
        private string _connectionString = "";

        public SQLiteContext()
        {
            _connectionString = "Data Source=BunnyDb.db;Version=3;";
            _dbConn = new SQLiteConnection(_connectionString);

            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public void Delete(string sql, object parameters = null)
        {
            using (_dbConn)
            {
                Open();
                _dbConn.Execute(sql, parameters);
            }
        }

        public int Insert<T>(string sql, object poco)
        {
            using (_dbConn)
            {
                Open();
                return _dbConn.ExecuteScalar<int>(sql, (T)poco);
            }
        }

        public void InsertBulk<T>(string sql, object listPoco)
        {
            using (_dbConn)
            {
                Open();
                using (SQLiteTransaction trans = _dbConn.BeginTransaction())
                {
                    _dbConn.Execute(sql, listPoco, transaction: trans);
                    trans.Commit();
                }
            }
        }

        public T Select<T>(string sql, object parameters = null) where T : new()
        {
            using (_dbConn)
            {
                Open();
                var o = _dbConn.Query<T>(sql, parameters).FirstOrDefault();
                if (o != null)
                    return o;

                return new T();
            }
        }

        public List<T> SelectList<T>(string sql, object parameters = null)
        {
            using (_dbConn)
            {
                Open();
                return _dbConn.Query<T>(sql, parameters).ToList();
            }
        }

        public void Update<T>(string sql, object poco)
        {
            using (_dbConn)
            {
                Open();
                _dbConn.Execute(sql, (T)poco);
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            using (_dbConn)
            {
                Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, _dbConn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        #region helpers
        public void Dispose()
        {
            _dbConn.Close();
            _dbConn.Dispose();
        }
        public void Open()
        {
            if (_dbConn.State == ConnectionState.Closed)
                _dbConn.Open();
        }
        #endregion
    }
}
