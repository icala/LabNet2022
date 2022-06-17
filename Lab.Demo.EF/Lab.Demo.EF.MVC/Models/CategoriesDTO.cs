using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Demo.EF.MVC.Models
{
    public class CategoriesDTO
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public CategoriesDTO()
        {

        }
        public CategoriesDTO(Categories category)
        {
            this.CategoryID = category.CategoryID;
            this.CategoryName = category.CategoryName;
            this.Description = category.Description;
        }
    }

}

