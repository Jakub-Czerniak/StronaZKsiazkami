using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Apartment { get; set; }
        public string Postcode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
    }
}
