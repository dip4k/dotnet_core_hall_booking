using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("Customers")]
  public partial class Customer
  {

    public int Id { get; set; }

    public string Address { get; set; }
    public string AadharNo { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
  }
}
