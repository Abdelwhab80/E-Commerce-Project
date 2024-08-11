using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public  string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,200)]
        public int DisplayOrder { get; set; }
    }
}
