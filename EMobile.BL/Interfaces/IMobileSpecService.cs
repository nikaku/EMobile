using EMobile.BL.Dtos.MobileSpecDtos;
using EMobile.BL.Entities;
using EMobile.BL.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL.Interfaces
{
    public interface IMobileSpecService
    {
        MobileSpec Get(int id);
        IEnumerable<MobileSpec> FindAll(MobileSpecsFilter filter);
        MobileSpec Add(MobileSpec mobileSpec);
        void Delete(int id);
    }
}
