using DPWA_Assessment.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DPWA_Assessment.Models;

namespace DPWA_Assessment.Controllers
{
    public class JuegoController : Controller
    {
        // GET: Juego
        public ActionResult Index()
        {
            List<JuegoViewModel> listaJuegos;
            using(juegoJECSEntities db = new juegoJECSEntities())
            {
                listaJuegos = (from data in db.juegoes
                               select new JuegoViewModel
                               {
                                   Id =  data.idjuego,
                                   NombreJuego = data.nomJuego,
                                   Existencias = (int)data.existencias,
                                   Imagen = data.imagen,
                                   Precio = (double)data.precio,
                                   IdCategoria = (int)data.idcategoria
                               }
                               ).ToList();
            }
            return View(listaJuegos);
        }
    }
}