
using EMobile.BL.Entities;
using EMobile.BL.Implementations;
using EMobile.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMobile.DB.Implementations
{
    public class MobileSpecsRepository : Repository<MobileSpec>, IMobileSpecsRepository
    {
        public MobileSpecsRepository(DataContext context) : base(context)
        {

        }

        private DataContext MobileSpecsContext => Context as DataContext;
    }
}
