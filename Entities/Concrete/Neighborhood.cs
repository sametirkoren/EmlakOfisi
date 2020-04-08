using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    [Table("Neighborhoods")]
    public class Neighborhood
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        public string Name { get; set; }

        public Neighborhood()
        {
            Adverts = new List<Advert>();
        }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        public virtual  ICollection<Advert> Adverts { get; set; }
      
    }
}
