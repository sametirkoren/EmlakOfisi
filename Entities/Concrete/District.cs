﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Districts")]
    public class District :IEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }


        public District()
        {
            Places = new List<Place>();
            Adverts = new List<Advert>();
        }
     
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }


        public virtual ICollection<Place> Places{ get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }

    }
}
