using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using DataTransferObjects;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRealEstateService
    {

        IDataResult<RealEstate> GetById(int realEstateId);
       /* IDataResult<List<RealEstate>> GetByAdvert(int advertId);*/

        List<RealEstate> GetList();

        IResult Add(RealEstate realEstate);

        IResult Delete(RealEstate realEstate);

        IResult Update(RealEstate realEstate);

        RealEstate GetByUsername(string username);


    }
}
