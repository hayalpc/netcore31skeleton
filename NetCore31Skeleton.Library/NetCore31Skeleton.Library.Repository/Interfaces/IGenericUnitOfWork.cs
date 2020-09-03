using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace NetCore31Skeleton.Library.Repository.Interfaces
{
    public interface IGenericUnitOfWork<TContext> : IDisposable
    {
        void BeginTransaction();

        void BeginTransaction(IsolationLevel level);

        void CommitTransaction();

        void RollBackTransaction();

        IDbContextTransaction UseTransaction(DbTransaction transaction);

        void SetIsolationLevel(IsolationLevel level);

        int ExecuteSqlCommand(FormattableString sql);
        int ExecuteSqlCommand(RawSqlString sql,  params object[] parameters);
        int ExecuteSqlCommand(RawSqlString sql, IEnumerable<object> parameters);

        int ExecuteSqlRaw(string sql, params object[] parameters);
        int ExecuteSqlRaw(string sql, IEnumerable<object> parameters);

        string GenerateCreateScript();

        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbConnection GetDbConnection();
        void OpenConnection();
        void CloseConnection();
    }
}
