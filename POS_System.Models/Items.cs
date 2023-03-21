using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_System.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}