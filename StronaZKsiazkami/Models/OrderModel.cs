using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StronaZKsiazkami.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Apartment { get; set; }
        public string Postcode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set;}

    }
}