using Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace Data
{
    public class TransactionManager : ITransactionManager
    {
        private DbTransaction _dbTransaction = null;
        private bool _isRootService = true;
        private MaintenanceContext _maintenanceContext { get; set; }

        public TransactionManager(MaintenanceContext maintenanceContext)
        {
            _maintenanceContext = maintenanceContext;
        }

        public void SetDbTransaction(DbTransaction dbTransaction = null)
        {
            this._dbTransaction = dbTransaction;
        }

        public void BeginTransaction(bool isRootService = true)
        {
            if (isRootService)
            {
                if (this._dbTransaction == null)
                {
                    this._dbTransaction = this._maintenanceContext.Database.BeginTransaction().GetDbTransaction();
                }
            }

        }

        public void CommitTransaction(bool isRootService = true)
        {
            if (isRootService)
            {
                this._dbTransaction.Commit();
                this._dbTransaction = null;
            }
        }

        public void RollbackTransaction(bool isRootService = true)
        {

            if (isRootService)
            {
                this._dbTransaction.Rollback();
                this._dbTransaction = null;
            }
        }
        public DbTransaction GetTransaction()
        {
            return this._dbTransaction;
        }
    }
}
