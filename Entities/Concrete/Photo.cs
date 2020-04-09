using System;
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
        public string Url { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        public Advert Advert { get; set; }
    }
}
