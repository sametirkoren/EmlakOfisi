using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    [Table("Districts")]
    public class District
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }


        public District()
        {
            Neighborhoods = new List<Neighborhood>();
            Adverts = new List<Advert>();
        }
     
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }


        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }

    }
}
