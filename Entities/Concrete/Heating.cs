using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Heating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Heating()
        {
            Adverts = new List<Advert>();
        }

        public virtual  ICollection<Advert> Adverts { get; set; }
    }
}
