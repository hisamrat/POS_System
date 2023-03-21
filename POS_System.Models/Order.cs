using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Models
{
  public  class Order
    {
        public string OrderId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string OrderTime { get; set; }
    }
}
