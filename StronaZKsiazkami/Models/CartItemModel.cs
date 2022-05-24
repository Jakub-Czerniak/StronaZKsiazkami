using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StronaZKsiazkami.Models
{
    public class CartItemModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public decimal Total { get; set; }

    }
}