using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository
    {
        protected MaintenanceContext maintenanceContext;
        public BaseRepository(MaintenanceContext maintenanceContext)
        {
            this.maintenanceContext = maintenanceContext;
        }
    }
}
