using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ComicBookCrud.Models
{
    public class ComicBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Comic Title")]
        public string Title { get; set; } = "";
        [Required]
        [DisplayName("Issue Number")]
        public int Issue {  get; set; }
        public string Description { get; set;}
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Display(Name = "Cover Price")]
        [Range(0, 1000)]
        public double CoverPrice { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
