using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPWA_Assessment.Models.ViewModel
{
    public class ViewModel
    {
        public List<CategoriaViewModel> Categorias { get; set; }
        public List<JuegoViewModel> Juegos { get; set; }

        public JuegoViewModel NuevoJuego { get; set; }
    }
}