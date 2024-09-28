using System.ComponentModel;
using System.ComponentModel.DataAnnotations;  // Add this line to import the DataAnnotations namespace

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]  // Corrected the attribute name to use a capital 'K'
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
