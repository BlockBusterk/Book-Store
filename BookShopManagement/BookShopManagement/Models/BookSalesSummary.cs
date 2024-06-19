using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopManagement.Models
{
    public class BookSalesSummary
    {
        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; } 
        public string Publisher { get; set; }
        public string Category { get; set; }
        public int TotalQuantitySold { get; set; }
        public double TotalRevenue { get; set; }
    }
}
