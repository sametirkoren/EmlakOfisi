﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    [Table("Photos")]
    public class Photo : IEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public int AdvertId { get; set; }
        [ForeignKey("AdvertId")]
        public string FileName { get; set; }

        public bool IsMain { get; set; }


        public virtual Advert Advert { get; set; }
    }
}
