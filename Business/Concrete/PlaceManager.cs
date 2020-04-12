using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PlaceManager:IPlaceService
    {
        private IPlaceDal _placeDal;

        public PlaceManager(IPlaceDal placeDal)
        {
            _placeDal = placeDal;
        }

        public List<Place> GetPlace(int id)
        {
            return _placeDal.GetList(p => p.District.Id == id).ToList();
        }
    }
}
