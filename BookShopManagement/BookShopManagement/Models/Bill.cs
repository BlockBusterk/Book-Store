using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{
    public class Bill
    {
        public string Title { get; set; } = "";
        public string Publisher { get; set; } = "";
        public string Author { get; set; } = "";
        public int Quantity { get; set; } = 0;
        public double Price { get; set; } = 0;
        public double TotalPrice => Price*Quantity;
    }
}
