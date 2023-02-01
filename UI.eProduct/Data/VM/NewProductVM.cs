using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.eProduct.Data.VM
{
    public class NewProductVM
    {
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Product category is required")]        
        public Guid ProductCategoryID { get; set; }

        [Display(Name = "Re Order Level")]
        [Required(ErrorMessage = "Re-Order is required")]
        [Range(1, 100, ErrorMessage = "Value must be between 1 and 100")]
        public int Re_OrderLevel { get; set; }

        [Display(Name = "Quantiry")]
        [Required(ErrorMessage = "Quantiry is required")]
        [Range(1, 100, ErrorMessage = "Value must be between 1 and 100")]
        public int Quantity { get; set; }
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Product is required")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Product image URL")]
        [Required(ErrorMessage = "Product image URL is required")]
        public string ImageURL { get; set; }
    }
}
