using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Models
{
  public  class Bill
    {
        public string BillId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int DiscountPercentage { get; set; }
        [Required]
        public int VatPercentage { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime BillDate { get; set; }
        [Required]
        public string BillTime { get; set; }
    }
}
