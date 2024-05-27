using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magazine.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        public List<Product> Products { get; set; }
    }
}
