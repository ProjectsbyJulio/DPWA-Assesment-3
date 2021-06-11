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
            List<JuegoViewModel> listaJuegos;
            using (juegoJECSEntities db = new juegoJECSEntities())
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

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult InsertarJuego(ViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (juegoJECSEntities db = new juegoJECSEntities())
                    {
                        var data = new juego();
                        data.nomJuego = model.NuevoJuego.NombreJuego;
                        model.NuevoJuego.Imagen = Path.GetFileName(model.NuevoJuego.ImagePath.FileName);
                        data.imagen = $"/Assets/Images/{model.NuevoJuego.Imagen}";
                        string path = Path.Combine(Server.MapPath("~/Assets/Images/"), Path.GetFileName(model.NuevoJuego.Imagen));
                        model.NuevoJuego.ImagePath.SaveAs(path);
                        data.precio = model.NuevoJuego.Precio;
                        data.existencias = model.NuevoJuego.Existencias;
                        data.idcategoria = model.NuevoJuego.IdCategoria;
                        db.juegoes.Add(data);
                        db.SaveChanges();
                    }
                    return Redirect("/Juego");
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