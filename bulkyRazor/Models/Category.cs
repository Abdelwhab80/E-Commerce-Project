using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace bulkyRazor.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 200)]
        public int DisplayOrder { get; set; }
    }
}

