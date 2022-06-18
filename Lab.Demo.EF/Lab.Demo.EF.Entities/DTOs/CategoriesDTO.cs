using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Demo.EF.Entities.DTOs
{
    public class CategoriesDTO
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Nombre de la Categoria")]
        public string CategoryName { get; set; }
        [Display(Name = "Descripción")]
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

