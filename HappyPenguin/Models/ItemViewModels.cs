using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyPenguin.Models
{
    public class ItemViewModels
    {
        public int ItemsId { get; set; }
        public string ItemName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}