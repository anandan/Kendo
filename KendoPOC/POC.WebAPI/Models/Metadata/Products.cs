using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Poc.WebApi.Models
{
    public partial class ProductMetadata
    {
        [Required(ErrorMessage = "Product Name Required!!!!!!")]
        [Remote("IsProductNameUnique", "Products", ErrorMessage = "Product Name Must be Unique")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Quantity Per Unit Required!!!!!!")]
        public string QuantityPerUnit { get; set; }
    }
}