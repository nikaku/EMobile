using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void Dispose();
        IMobileSpecsRepository MobileSpecsRepository { get; }
    }
}
