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
        [Required(ErrorMessage = "Książka musi mieć tytuł.")]
        [StringLength(255, ErrorMessage = "Title too long.")]
        public string Title { get; set; }
        [Display(Name = "Author First Name")]
        [Required(ErrorMessage = "Książka musi mieć autora.")]
        [StringLength(50, ErrorMessage = "Name too long.")]
        public string AuthorFirstName { get; set; }
        [Display(Name = "Author Last Name")]
        [Required(ErrorMessage = "Książka musi mieć autora.")]
        [StringLength(50, ErrorMessage = "Name too long.")]
        public string AuthorLastName { get; set; }
        [StringLength(2550, ErrorMessage = "Description too long.")]
        public string Description { get; set; }

        [Range(1,32767, ErrorMessage = "Wpisz liczbę książek do 32 767")]
        [Required(ErrorMessage = "Musimy wiedzieć ile jest książek.")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Książka musi mieć cene.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}