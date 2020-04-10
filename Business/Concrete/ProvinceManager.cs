using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProvinceManager : IProvinceService
    {
        private IProvinceDal _provinceDal;

        public ProvinceManager(IProvinceDal provinceDal)
        {
            _provinceDal = provinceDal;
        }

        public List<Province> GetList()
        {
            return _provinceDal.GetList().ToList();
        }
    }
}
