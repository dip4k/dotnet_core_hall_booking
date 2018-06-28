using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarriageHall.BOL
{
  [Table("FeaturePrices")]
  public partial class FeaturePrice
  {
    public int Id { get; set; }
    public decimal HallPrice { get; set; }
    public decimal? CateringPrice { get; set; }
    public decimal? BanjoPrice { get; set; }
    public decimal? FlowerPrice { get; set; }
    public int HallOwnerId { get; set; }

    public HallOwner HallOwner { get; set; }
  }
}
