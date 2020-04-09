using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("AdvertType")]
    public class AdvertType : IEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }

        public AdvertType()
        {
            Adverts = new List<Advert>();
        }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
