using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Data.Models
{
    public class Item
    {
        [Key]
        public int ItemsId { get; set; }
        public string ItemName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
