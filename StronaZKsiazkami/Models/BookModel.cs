using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StronaZKsiazkami.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A book should have a title.")]
        [StringLength(255, ErrorMessage = "Title too long.")]
        public string Title { get; set; }
        [Display(Name = "Author First Name")]
        [Required(ErrorMessage = "An author should have a name.")]
        [StringLength(50, ErrorMessage = "Name too long.")]
        public string AuthorFirstName { get; set; }
        [Display(Name = "Author Last Name")]
        [Required(ErrorMessage = "An author should have a last name.")]
        [StringLength(50, ErrorMessage = "Name too long.")]
        public string AuthorLastName { get; set; }
        [StringLength(2550, ErrorMessage = "Description too long.")]
        public string Description { get; set; }

        [Range(1,32767, ErrorMessage = "Maximum number of books is 32 767.")]
        [Required(ErrorMessage = "There ought to be a number of books to put in database.")]
        public int Amount { get; set; }
        [Range(1.0, 300.0, ErrorMessage = "Price should fit in range 1.00 - 300.00.")]
        [Required(ErrorMessage = "We cannot give away books for free.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Display(Name = "Genres")]
        [Required(ErrorMessage ="A book should have at least one genre assigned.")]
        [StringLength(255, ErrorMessage = "Name too long.")]
        public string Genres { get; set; }
    }
}