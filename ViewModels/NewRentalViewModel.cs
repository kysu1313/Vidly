﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewRentalViewModel
    {
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}