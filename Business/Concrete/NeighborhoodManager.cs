using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NeighborhoodManager:INeighborhoodService
    {
        private INeighborhoodDal _neighborhoodDal;

        public NeighborhoodManager(INeighborhoodDal neighborhoodDal)
        {
            _neighborhoodDal = neighborhoodDal;
        }

        public List<Neighborhood> GetNeighborhood(int id)
        {
            return _neighborhoodDal.GetList(n => n.Place.Id == id);
        }
    }
}
