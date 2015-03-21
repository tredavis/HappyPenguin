using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Data.Models
{
    public class HappyShopper
    {
        [Key]
        public int HappyShopperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string State { get; set; }
        public string TX { get; set; }

        public int Zip { get; set; }

        
    }
}
