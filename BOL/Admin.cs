using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("Admins")]
  public partial class Admin
  {
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
  }
}
