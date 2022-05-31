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
        [Required(ErrorMessage = "You must input your username to publish a review.")]
        [StringLength(255, ErrorMessage = "Username to long, maximum number of characters = 255.")]
        public string Username { get; set; }

        public int BookId { get; set; }
        [Required(ErrorMessage = "You have to rate a book in order to publish a review.")]
        [Range(1, 10, ErrorMessage = "Rating should be in range 1-10.")]
        public int Rating { get; set; }
        [StringLength(2550, ErrorMessage = "Maximum number of characters:2550.")]
        public string TextReview { get; set; }

    }
}