using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Data.Models
{

    //public class Walmart
    //{
    //    Walmart.SDK.Core.WalmartClient client = new Walmart.SDK.Core.WalmartClient("<api_key>");
    //}
    public class RecentlyBought
    {
        [Key]
        public int RecentlyBoughtId { get; set; }
       // public int ItemId { get; set; }
        //[ForeignKey("ItemsId"), InverseProperty("")]
        //[InverseProperty("ItemsId")] 
        //public virtual Item Item { get; set; }
        public decimal Price { get; set; }
        public int HappyCartId { get; set; }
        [ForeignKey("HappyCartId")]
        public virtual HappyCart HappyCart { get; set; }
    }
}
