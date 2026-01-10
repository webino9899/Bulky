using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulyWebRazor_Temp.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
