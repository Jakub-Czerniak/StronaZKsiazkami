using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StronaZKsiazkami.Models
{
    public class EmployeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(255, ErrorMessage = "Email too long.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Password too long.")]
        [DataType(DataType.Password)]
        public string Password  { get; set; }
    }
}