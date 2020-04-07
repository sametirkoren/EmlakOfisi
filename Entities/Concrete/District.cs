using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public District()
        {
            Neighborhoods = new List<Neighborhood>();
            RealEstates = new List<RealEstate>();
            Adverts = new List<Advert>();
        }

        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }


        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
        public virtual ICollection<RealEstate> RealEstates{ get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }

    }
}
