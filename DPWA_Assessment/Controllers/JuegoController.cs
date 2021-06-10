using DPWA_Assessment.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DPWA_Assessment.Models;
using System.IO;

namespace DPWA_Assessment.Controllers
{
    public class JuegoController : Controller
    {
        ViewModel viewModel = new ViewModel();
        // GET: Juego
        public ActionResult Index()
        {
       
            using (juegoJECSEntities db = new juegoJECSEntities())
            {
                viewModel.Juegos = db.juegoes.Join(
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
            return View(viewModel.Juegos);
        }

        public ActionResult InsertarJuego()
        {
            using (juegoJECSEntities db = new juegoJECSEntities())
            {
                viewModel.Categorias = (from data in db.categorias
                                   select new CategoriaViewModel
                                   {
                                       Id = data.idcategoria,
                                       Categoria = data.categoria1
                                   }
                                   ).ToList();
            }

            return View(viewModel.Categorias);
        }

        [HttpPost]
        public ActionResult InsertarJuego(JuegoViewModel model)
        {
            try
            {
                using (juegoJECSEntities db = new juegoJECSEntities())
                {
                    var data = new juego();
                    data.nomJuego = model.NombreJuego;
                    model.Imagen = Path.GetFileName(model.ImagePath.FileName);
                    data.imagen = $"/Assets/Images/{model.Imagen}";
                    string path = Path.Combine(Server.MapPath("~/Assets/Images/"), Path.GetFileName(model.Imagen));
                    model.ImagePath.SaveAs(path);
                    data.precio = model.Precio;
                    data.existencias = model.Existencias;
                    data.idcategoria = model.IdCategoria;
                    db.juegoes.Add(data);
                    db.SaveChanges();
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}