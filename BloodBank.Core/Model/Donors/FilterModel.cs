﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Model.Donors
{
   public class FilterModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
      
        public int? PhoneNumber { get; set; }
    }
}
