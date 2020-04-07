using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Photo
    {
        public int Id { get; set; }
        public int AdvertId { get; set; }
        public string Url { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        public Advert Advert { get; set; }
    }
}
