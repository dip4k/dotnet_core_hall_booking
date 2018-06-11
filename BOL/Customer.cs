using System;
using System.Collections.Generic;

namespace MarriageHall.BOL
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
