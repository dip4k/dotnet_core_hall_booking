using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageHall.Controllers.Resources
{
    public class CustomerResource
    {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string AadharNo { get; set; }
   
    public UserResource User { get; set; }
  }
}
