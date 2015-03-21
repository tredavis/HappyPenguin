using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyPenguin.Models
{
    public class HappyShopperViewModel
    {
        public int HappyShopperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string TX { get; set; }
        public int Zip { get; set; }
    }
}