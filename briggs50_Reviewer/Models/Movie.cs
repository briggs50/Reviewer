using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace briggs50_Reviewer.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [Display(Name = "ReleaseDate")]
        [DataType(DataType.Date)]
        public int Year { get; set; }

        [Required(ErrorMessage = "Leading actor is required")]
        public string LeadingActor { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        public string MoviePoster { get; set; }

        public ICollection<Review> Reviews { get; set; }

        [Required(ErrorMessage = "Movie Rating is required")]
        public MovieRating Rating { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; }
    }
}