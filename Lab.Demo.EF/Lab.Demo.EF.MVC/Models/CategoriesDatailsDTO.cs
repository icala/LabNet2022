using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Demo.EF.MVC.Models
{
    public class CategoriesDatailsDTO
    {
        public CategoriesDTO Category { get; set; }
        public List<ProductsDTO> Products { get; set; }
    }
}