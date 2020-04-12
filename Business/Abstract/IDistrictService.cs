using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDistrictService
    {
        List<District> GetDistrict(int id);
    }
}
