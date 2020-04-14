using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
