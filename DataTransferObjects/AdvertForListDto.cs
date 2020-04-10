using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataTransferObjects
{
    public class AdvertForListDto
    {
       
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


        public virtual ProvinceDto Province { get; set; }


        public virtual DistrictDto District { get; set; }


        public virtual PlaceDto Place { get; set; }
        public virtual NeighborhoodDto Neighborhood { get; set; }

        

        public virtual RealEstateDto RealEstate { get; set; }

        

        public virtual AdvertTypeDto AdvertType { get; set; }

        

        public virtual HeatingDto Heating { get; set; }

        public virtual ICollection<PhotoDto> Photos { get; set; }

    }

  

    public class RealEstateDto
    {
        public string CompanyName { get; set; }

        public string UserName { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }
    }

    public class ProvinceDto
    {
        public string Name { get; set; }
    }

    public class PhotoDto
    {
        public string FileName { get; set; }
        public bool IsMain { get; set; }


    }
    public class PlaceDto
    {
        public string Name { get; set; }
    }

    public class NeighborhoodDto
    {
        public string Name { get; set; }
        public int PostCode { get; set; }
    }

    public class HeatingDto
    {
        public string Name { get; set; }
    }

    public class DistrictDto
    {
        public string Name { get; set; }
    }

    public class AdvertTypeDto
    {
        public string Name { get; set; }

    }
}
