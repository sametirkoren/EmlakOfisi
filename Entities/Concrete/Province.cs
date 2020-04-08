using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    [Table("Provinces")]
    public class Province
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }

        public Province()
        {
            Districts = new List<District>();
            Adverts = new List<Advert>();
        }


        public virtual ICollection<Advert> Adverts { get; set; }
        public virtual ICollection<District> Districts { get; set; }

       
        
    }
}
