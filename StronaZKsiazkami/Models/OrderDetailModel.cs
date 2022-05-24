using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StronaZKsiazkami.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }


    }
}