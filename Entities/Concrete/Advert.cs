using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Advert :IEntity
    {
        public Advert()
        {
            Photos = new List<Photo>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage="Oda Sayısı Gerekli")]
        [Range(1,50)]
        public short RoomCount { get; set; }
        [Required(ErrorMessage = "Bina Yaşı Gerekli")]
        [Range(1, 100)]
        public short BuildAge { get; set; }
     
        [Range(1,200)]
        [Required(ErrorMessage = "Bina Kat Sayısı Gerekli")]
        public short BuildFloor { get; set; }
        [Range(1,200)]
        [Required(ErrorMessage = "Kat Sayısı Gerekli")]
        public short Floor { get; set; }
        [Range(1,5000)]
        [Required(ErrorMessage = "Metre Kare Sayısı")]
        public int SquareMeter { get; set; }

        public DateTime ListingDate { get; set; }
        [Required(ErrorMessage = "Açıklama Gerekli")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Başlık Gerekli")]
        public string Title { get; set; }

        public bool IsLive { get; set; }
        [Required(ErrorMessage = "Fiyat Gerekli")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Adres Gerekli")]
        public string Address { get; set; }

        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }


        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place{ get; set; }

        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public int AdvertTypeId { get; set; }

        public virtual AdvertType AdvertType { get; set; }

        public int HeatingId { get; set; }

        public virtual Heating Heating { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        [NotMapped]
        public IFormFile[] Files { get; set; }  



    }
}
