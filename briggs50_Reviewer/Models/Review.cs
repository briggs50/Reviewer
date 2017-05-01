using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace briggs50_Reviewer.Models
{
    public enum MovieRating
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        F = 4
    }
    public class Review
    {
        [Required(ErrorMessage = "Your review content is required")]
        public string Content { get; set; }

        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public MovieRating Rating { get; set; }
    }
}