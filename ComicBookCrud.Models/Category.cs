using System.ComponentModel;
using System.ComponentModel.DataAnnotations; // Adds various annotations to properties, like primary Key and required data

namespace ComicBookCrud.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = "";
        [DisplayName("Display Order")]
        [Range(1, 100)] // Can also use 'ErrorMessage = "MESSAGE HERE"' as a third parameter in Range for a custom Error Message
        public int DisplayOrder { get; set; }
    }
}
