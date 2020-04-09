using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Place : IEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        public string Name { get; set; }

        
        public Place()
        {
            Neighborhoods = new List<Neighborhood>();
            Adverts = new List<Advert>();
        }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
