﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentCurrency
{
    public class ValuteModel
    {
        public string ID { get; set; }

        public int NumCode { get; set; }

        public string CharCode { get; set; }

        public int Nominal { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public decimal VunitRate { get; set; }
    }
}
