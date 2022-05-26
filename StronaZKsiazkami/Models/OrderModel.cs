using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StronaZKsiazkami.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please input your name.")]
        [StringLength(50, ErrorMessage = "Name too long")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please input your name.")]
        [StringLength(50, ErrorMessage = "Name too long")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please input your city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please input your adress.")]
        [StringLength(255, ErrorMessage = "Adress too long")]
        public string Adress { get; set; }
        [StringLength(10, ErrorMessage = "Apartment too long")]
        public string Apartment { get; set; }
        [StringLength(6, ErrorMessage = "Postal code too long")]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }
        [Required(ErrorMessage = "Please input your adress.")]
        [StringLength(255, ErrorMessage = "Status too long")]
        public string Status { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set;}

    }
}