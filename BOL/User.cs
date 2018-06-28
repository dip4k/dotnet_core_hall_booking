using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("Users")]
  public partial class User
  {


    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string MobileNo { get; set; }
    public string Role { get; set; }


  }
}
