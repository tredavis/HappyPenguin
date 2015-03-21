using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Data.Models
{
    public class HappyCart
    {
        [Key]
        public int HappyCartId { get; set; }

        public decimal Total { get; set; }
        public int OrderItemsId { get; set; }
        [ForeignKey("OrderItemsId")]
        public virtual OrderItems OrderItems { get; set; }
        public int HappyShopperId { get; set; }
        [ForeignKey("HappyShopperId")]
        public virtual HappyShopper HappyShopper { get; set; }

    }
}
