using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class AppController : Controller
    {
        // GET: AppController

        private static List<MovieModel> _movieModel = new List<MovieModel>();

        public ActionResult Index()
        {


            return View(_movieModel);
        }

        // GET: AppController
        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult AddOrEdit(int id)
        {
            //Con el FirtOrDefault decimos que si existe nos trae uno y si no manda uno nuevo
            var movie = _movieModel.FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        // POST: AppController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(int id, MovieModel movieModel)
        {
            //El ModelState nos sirve para que valide las restricciones en las propiedades del modelo
            if (ModelState.IsValid)
            {
                var movie = _movieModel.FirstOrDefault(m => m.Id == id);

                if (movie == null)
                {
                    int count = _movieModel.Count;
                    movieModel.Id = count + 1;
                    _movieModel.Add(movieModel);
                }
                else
                {
                    movie.Genero = movieModel.Genero;
                    movie.Nombre = movieModel.Nombre;
                }
                
                return RedirectToAction(nameof(Index));
            }
            
            return View();
             
        }

        // GET: AppController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            var movie = _movieModel.First(m => m.Id == id);

            if (movie != null)
            {
                _movieModel.Remove(movie);
                return RedirectToAction(nameof(Index));
            }
                return View();
            
        }
    }
}
