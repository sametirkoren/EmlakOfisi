using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Heatings")]
    public class Heating : IEntity
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
