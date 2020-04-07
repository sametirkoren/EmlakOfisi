using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Advert
    {
        public Advert()
        {
            Photos = new List<Photo>();
        }
        public int Id { get; set; }
        public short RoomCount { get; set; }

        public short BuildAge { get; set; }

        public short BuildFloor { get; set; }

        public short Floor { get; set; }

        public int SquareMeter { get; set; }

        public DateTime ListingDate { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public bool IsLive { get; set; }

        public decimal Price { get; set; }

        public string Address { get; set; }

        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public int AdvertTypeId { get; set; }

        public virtual AdvertType AdvertType { get; set; }

        public int HeatingId { get; set; }

        public virtual Heating Heating { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }



    }
}
