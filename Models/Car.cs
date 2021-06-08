using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BookACar.Models
{
    public class Car
    {
        public string RegNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string Available { get; set; }
    }
}
