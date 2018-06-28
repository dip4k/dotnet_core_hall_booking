using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("HallDetails")]
  public partial class HallDetail
  {
    public int Id { get; set; }
    public string HallName { get; set; }
    public int HallCapacity { get; set; }
    public int HallOwnerId { get; set; }

    //foreign Table
    public HallOwner HallOwner { get; set; }
  }
}
