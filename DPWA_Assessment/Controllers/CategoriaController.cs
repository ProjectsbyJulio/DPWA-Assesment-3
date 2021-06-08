using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DPWA_Assessment.Models;
using DPWA_Assessment.Models.ViewModel;

namespace DPWA_Assessment.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            List<CategoriaViewModel> listaCategorias;
            using (juegoJECSEntities db = new juegoJECSEntities())
            {
                listaCategorias = (from data in db.categorias
                                   select new CategoriaViewModel
                                   {
                                       Id = data.idcategoria,
                                       Categoria = data.categoria1,
                                       imagenCat = data.imagenCat
                                   }
                                   ).ToList();
            }

            return View(listaCategorias);
        }
    }
}