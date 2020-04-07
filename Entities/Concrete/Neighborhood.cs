using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Neighborhood
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Neighborhood()
        {
            RealEstates = new List<RealEstate>();
            Adverts = new List<Advert>();
        }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public virtual  ICollection<Advert> Adverts { get; set; }
        public virtual  ICollection<RealEstate> RealEstates { get; set; }
    }
}
