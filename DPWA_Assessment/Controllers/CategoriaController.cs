using System;
using System.Collections.Generic;
using System.IO;
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
                                       ImagenCat = data.imagenCat
                                   }
                                   ).ToList();
            }

            return View(listaCategorias);
        }

        public ActionResult InsertarCategoria()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarCategoria(CategoriaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (juegoJECSEntities db = new juegoJECSEntities())
                    {
                        
                        var data = new categoria();
                        data.categoria1 = model.Categoria;
                        model.ImagenCat = Path.GetFileName(model.ImagePath.FileName);
                        data.imagenCat = $"/Assets/Images/{model.ImagenCat}";
                        string path = Path.Combine(Server.MapPath("~/Assets/Images/"), Path.GetFileName(model.ImagenCat));
                        model.ImagePath.SaveAs(path);
                        db.categorias.Add(data);
                        db.SaveChanges();
                    }
                    return Redirect("/Categoria");
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