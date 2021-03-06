﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IHeatingService
    {
        IDataResult<Heating> GetById(int heatingId);
        IResult Add(Heating heating);

        IResult Delete(Heating heating);

        IResult Update(Heating heating);

        List<Heating> GetList();
    }
}
