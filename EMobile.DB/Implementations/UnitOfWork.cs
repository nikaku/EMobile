
using EMobile.BL.Interfaces;
using EMobile.DB;
using EMobile.DB.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            MobileSpecsRepository = new MobileSpecsRepository(_dataContext);

        }
        public IMobileSpecsRepository MobileSpecsRepository { get; }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}
