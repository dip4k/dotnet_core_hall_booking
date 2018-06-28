using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("Admins")]
  public partial class Admin
  {
    public int AdminId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
  }
}
