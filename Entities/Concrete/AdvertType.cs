using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AdvertType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AdvertType()
        {
            Adverts = new List<Advert>();
        }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
