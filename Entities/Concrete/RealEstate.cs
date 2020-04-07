using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RealEstate
    {
        public RealEstate()
        {
            Adverts = new List<Advert>();
        }
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }

        public int DistrictId { get; set; }
        public virtual District District  { get; set; }

        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
