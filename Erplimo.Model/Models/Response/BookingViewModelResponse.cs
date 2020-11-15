using System;
using System.Collections.Generic;

namespace Erplimo.Model.Models.Response
{
    public class BookingViewModelResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public FlightViewModelResponse FlightViewModel { get; set; }
        public List<TravellerViewModelResponse> TravellerViewModels { get; set; }
        public PaymentViewModelResponse PaymentViewModel { get; set; }
        public ConfirmationInfoViewModelResponse ConfirmationInfoViewModel { get; set; }
    }
}
