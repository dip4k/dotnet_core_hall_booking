using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("HallOwners")]
  public partial class HallOwner
  {

    public int Id { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }

  }
}
