﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.Services.Interfaces.DTO.Service
{
    public class ServiceRequest
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public decimal Cost { get; set; }

        public int JourneyId { get; set; }
    }
}
