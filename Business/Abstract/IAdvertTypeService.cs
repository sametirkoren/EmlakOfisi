using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdvertTypeService
    {
        IDataResult<AdvertType> GetById(int advertTypeId);
        IResult Add(AdvertType advertType);

        IResult Delete(AdvertType advertType);

        IResult Update(AdvertType advertType);

        List<AdvertType> GetList();
    }
}
