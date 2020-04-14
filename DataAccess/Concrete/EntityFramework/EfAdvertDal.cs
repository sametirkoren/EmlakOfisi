using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdvertDal : EfEntityRepositoryBase<Advert,EmlakOfisiContext> , IAdvertDal
    {
        public List<Advert> MapToAdvertForList()
        {
            using (var context = new EmlakOfisiContext())
            {
                var advert = context.Adverts.Include(a => a.Photos).Include(a => a.RealEstate).Include(a => a.AdvertType).Include(a => a.Heating).Include(a => a.Province).Include(a=>a.District).Include(a=>a.Place).Include(a=>a.Neighborhood).ToList();
                return advert;
            }
        }

        public Advert MapToAdvert(int id)
        {
            using (var context = new EmlakOfisiContext())
            {
                var advert = context.Adverts.Include(a => a.Photos).Include(a => a.RealEstate).Include(a => a.AdvertType).Include(a => a.Heating).Include(a => a.Province).Include(a => a.District).Include(a => a.Place).Include(a => a.Neighborhood).FirstOrDefault(a=>a.Id == id);
                return advert;
            }
        }

        public Advert AdvertToPhoto(int id)
        {
            using (var context = new EmlakOfisiContext())
            {
                var advert = context.Adverts.Include(a => a.Photos).FirstOrDefault(a => a.Id == id);
                return advert;
            }
        }
    }
}
