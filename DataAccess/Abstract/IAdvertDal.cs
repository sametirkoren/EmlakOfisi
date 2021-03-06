﻿using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAdvertDal : IEntityRepository<Advert>
    {
        List<Advert> MapToAdvertForList();

        Advert MapToAdvert(int id);

        Advert AdvertToPhoto(int id);

    }
}
