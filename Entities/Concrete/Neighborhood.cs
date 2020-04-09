using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Neighborhoods")]
    public class Neighborhood : IEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int PostCode { get; set; }


        public Neighborhood()
        {
            Adverts = new List<Advert>();
        }

        public int PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place Place{ get; set; }

        public virtual  ICollection<Advert> Adverts { get; set; }
      
    }
}
