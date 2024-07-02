using System.ComponentModel.DataAnnotations; // Adds various annotations to properties, like primary Key and required data

namespace ComicBooksWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
