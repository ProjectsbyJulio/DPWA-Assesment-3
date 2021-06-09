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
                listaJuegos = db.juegoes.Join(
                        db.categorias,
                        juego => juego.idcategoria,
                        categoria => categoria.idcategoria,
                        (juego, categoria) => new JuegoViewModel
                        {
                            Id = juego.idjuego,
                            NombreJuego = juego.nomJuego,
                            Existencias = (int)juego.existencias,
                            Imagen = juego.imagen,
                            Precio = (double)juego.precio,
                            Categoria = categoria.categoria1
                        }
                    ).ToList();
            }
            return View(listaJuegos);
        }
    }
}