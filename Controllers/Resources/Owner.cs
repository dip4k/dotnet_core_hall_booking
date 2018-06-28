using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageHall.Controllers.Resources
{
  public class OwnerResource
  {
    public int Id { get; set; }

    public UserResource User { get; set; }
  }
}
