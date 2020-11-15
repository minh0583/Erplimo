using System;
using System.Collections.Generic;

namespace Erplimo.Data.Models
{
    public partial class TravellerOrder
    {
        public Guid TravellerId { get; set; }
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
        public Traveller Traveller { get; set; }
    }
}
