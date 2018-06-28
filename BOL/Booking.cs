using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("Bookings")]
  public partial class Booking
  {
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public int HallOwnerId { get; set; }
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
    public HallOwner HallOwner { get; set; }
  }
}
