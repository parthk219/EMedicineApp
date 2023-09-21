using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMedicineApp.Models
{
    public class Users
    {

        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string  Type { get; set; }
        public int  Status { get; set; }
        public DateTime  CreatedOn { get; set; }
    }
}
