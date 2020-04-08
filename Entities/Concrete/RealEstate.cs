using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    [Table("RealEstates")]
    public class RealEstate
    {
        public RealEstate()
        {
            Adverts = new List<Advert>();
        }
        [Key]
        [Column(Order=1)]
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
