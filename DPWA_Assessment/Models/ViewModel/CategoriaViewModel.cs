using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DPWA_Assessment.Models.ViewModel
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Categoria { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Imagen")]
        public string imagenCat { get; set; }
    }
}