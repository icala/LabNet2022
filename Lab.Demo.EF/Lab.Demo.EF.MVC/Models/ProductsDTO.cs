using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Demo.EF.MVC.Models
{
    public class ProductsDTO
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        public ProductsDTO (Products product)
        {
            this.ProductID = product.ProductID;
            this.ProductName = product.ProductName;
        }
    }
}