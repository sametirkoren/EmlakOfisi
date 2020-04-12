using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }



        [NotMapped]
        public string Password { get; set; }
    }
}
