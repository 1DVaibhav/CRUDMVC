using System.ComponentModel.DataAnnotations;


namespace CRUDMVC.Models
{
    //>*Product.cs* *-^


    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
    }


}
