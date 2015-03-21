using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Data.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }

        public int ItemsId { get; set; }
        [ForeignKey("ItemsId")]
        public virtual Item Item { get; set; }
        public DateTime? DatePurchased { get; set; }

        public int HappyShopperId { get; set; }
        public virtual HappyShopper HappyShopper { get; set; }


    }
}
