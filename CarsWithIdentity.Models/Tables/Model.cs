﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }
        public string UserId { get; set; }
        public string ModelName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
