using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace StronaZKsiazkami.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nie możesz wystawić oceny bez nazwy użytkownika.")]
        [StringLength(255, ErrorMessage = "Nazwa użytkownika za długa.")]
        public string Username { get; set; }

        public int BookId { get; set; }
        [Required(ErrorMessage = "Musisz wpisać ocenę.")]
        [Range(1, 10, ErrorMessage = "Wpisz ocenę w przedziale 1-10.")]
        public int Rating { get; set; }
        [StringLength(2550, ErrorMessage = "Opinia jest za długa.Limit znaków: 2550.")]
        public string TextReview { get; set; }

    }
}