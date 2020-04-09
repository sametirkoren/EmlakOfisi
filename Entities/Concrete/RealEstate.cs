using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("RealEstates")]
    public class RealEstate : IEntity
    {
        public RealEstate()
        {
            Adverts = new List<Advert>();
        }
        [Key]
        [Column(Order=1)]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
