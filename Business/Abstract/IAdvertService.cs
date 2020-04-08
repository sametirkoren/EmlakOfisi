using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using DataTransferObjects;

namespace Business.Abstract
{
    public interface IAdvertService
    {
        IDataResult<Advert> GetById(int advertId);
        IDataResult<List<Advert>> GetByRealEstate(int realEstateId);

        IResult Add(Advert advert);

        IResult Delete(Advert advert);

        IResult Update(Advert advert);

        List<AdvertForListDto> GetList();
    }
}
