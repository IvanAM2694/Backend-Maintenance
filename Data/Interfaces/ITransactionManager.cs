using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ITransactionManager
    {
        void SetDbTransaction(DbTransaction transaction = null);
        void CommitTransaction(bool isRootService = true);
        void RollbackTransaction(bool isRootService = true);
        void BeginTransaction(bool isRootService = true);
        DbTransaction GetTransaction();
    }
}
