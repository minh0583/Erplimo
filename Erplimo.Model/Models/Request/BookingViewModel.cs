﻿using System;
using System.Collections.Generic;

namespace Erplimo.Model.Models.Request
{
    public class BookingViewModel
    {
        public string Code { get; set; }
        public FlightViewModel FlightViewModel { get; set; }
        public List<TravellerViewModel> Travellers { get; set; }
        public PaymentViewModel PaymentViewModel { get; set; }
        public ConfirmationInfoViewModel ConfirmationInfoViewModel { get; set; }
    }
}
