﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Erplimo.Model.Models.Request;

namespace Erplimo.Model.Models.Response
{
    public class PaymentViewModelResponse : PaymentViewModel
    {
        public Guid Id { get; set; }
    }
}
