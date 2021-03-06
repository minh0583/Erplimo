﻿using System;
using AutoMapper;
using Erplimo.Data.Models;
using Erplimo.Model.Models.Request;
using Erplimo.Model.Models.Response;

namespace Erplimo.Rest.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookingRequest, Order>()
                .ForMember(p => p.CreatedDate, opt => opt.MapFrom(p => DateTime.Now));

            CreateMap<Order, BookingViewModelResponse>()
                .ForMember(p => p.PaymentViewModel, opt => opt.MapFrom(p => p.Payment))
                .ForMember(p => p.ConfirmationInfoViewModel, opt => opt.MapFrom(p => p.Confirmation))
                .ForMember(p => p.FlightViewModel, opt => opt.MapFrom(p => p.Flight));

            CreateMap<Payment, PaymentViewModelResponse>();
            CreateMap<ConfirmationInfo, ConfirmationInfoViewModelResponse>();
            CreateMap<Flight, FlightViewModelResponse>();
            CreateMap<Traveller, TravellerViewModelResponse>();

            CreateMap<PaymentViewModel, Payment>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()))
                .ForMember(p => p.CreatedDate, opt => opt.MapFrom(p => DateTime.Now));

            CreateMap<ConfirmationInfoViewModel, ConfirmationInfo>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()))
                .ForMember(p => p.CreatedDate, opt => opt.MapFrom(p => DateTime.Now));

            CreateMap<TravellerViewModel, Traveller>()
                .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()))
                .ForMember(p => p.CreatedDate, opt => opt.MapFrom(p => DateTime.Now));
        }
    }
}
