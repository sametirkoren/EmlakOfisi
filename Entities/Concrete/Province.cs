using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Province()
        {
            Districts = new List<District>();
            RealEstates = new List<RealEstate>();
            Adverts = new List<Advert>();
        }


        public virtual ICollection<Advert> Adverts { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }
       
        
    }
}
