using EMobile.BL.Entities;
using EMobile.BL.Filters;
using EMobile.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EMobile.BL.Services
{
    public class MobileSpecService : IMobileSpecService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MobileSpecService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MobileSpec Add(MobileSpec mobileSpec)
        {
            var mobilespecAdded = _unitOfWork.MobileSpecsRepository.Add(mobileSpec);
            _unitOfWork.SaveChanges();
            return mobilespecAdded;
        }

        public void Delete(int id)
        {
            var mobileSpec = _unitOfWork.MobileSpecsRepository.Get(id);
            _unitOfWork.MobileSpecsRepository.Remove(mobileSpec);
            _unitOfWork.SaveChanges();
        }

        public MobileSpec Get(int id)
        {
            var mobileSpec = _unitOfWork.MobileSpecsRepository.Get(id);
            if (mobileSpec == null)
            {
                return null;
            }
            return mobileSpec;
        }
        public IEnumerable<MobileSpec> FindAll(MobileSpecsFilter filter)
        {
            var mobileSpec = _unitOfWork.MobileSpecsRepository
               .FindAll(x =>
               (filter.Company == null || x.Company == filter.Company) &&
               (filter.FromPrice == null || x.Price > filter.FromPrice) &&
               (filter.ToPrice == null || x.Price < filter.ToPrice))
               .Skip((filter.CurrentPage - 1) * filter.PageSize)
                .Take(filter.PageSize);
            return mobileSpec.ToList();

        }




    }
}
