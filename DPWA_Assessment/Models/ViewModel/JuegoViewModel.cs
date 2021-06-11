using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DPWA_Assessment.Models.ViewModel
{
    public class JuegoViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string NombreJuego { get; set; }
        public double Precio { get; set; }
        public int Existencias { get; set; }
        public string Imagen { get; set; }
        public HttpPostedFileBase ImagePath { get; set; }
        public string Categoria { get; set; }
        public int IdCategoria { get; set; }
    }
}