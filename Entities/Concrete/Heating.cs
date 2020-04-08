using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    [Table("Heatings")]
    public class Heating
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Heating()
        {
            Adverts = new List<Advert>();
        }

        public virtual  ICollection<Advert> Adverts { get; set; }
    }
}
