using System;
using System.Collections.Generic;

namespace Erplimo.Model.Models.Request
{
    public class BookingRequest
    {
        public Guid FlightId { get; set; }
        public List<Guid> TravellerIds { get; set; }
        public Guid PaymentId { get; set; }
        public Guid ConfirmationId { get; set; }
    }
}
