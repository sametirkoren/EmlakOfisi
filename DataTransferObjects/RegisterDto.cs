using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string CompanyName { get; set; }

        public string Password { get; set; }
    }
}
