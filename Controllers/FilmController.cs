using Film3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film3.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Filmy> films = new List<Filmy>
        {
            new Filmy(){Id = 1, name = "Film1", description = "opis1", price=4 },
            new Filmy(){Id = 2, name = "Film2", description = "opis2", price=5 },
            new Filmy(){Id = 3, name = "Film3", description = "opis3", price=6 },
        };
        private Filmy film;

        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Filmy());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filmy film)
        {
            film.Id = films.Count +1;  
            films.Add(film);
                return RedirectToAction(nameof(Index));


        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);  
            if (film == null)
            {
                return NotFound();  
            }
            return View(film);  
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Filmy film)
        {
            var existingFilm = films.FirstOrDefault(x => x.Id == id);  
            if (existingFilm == null)
            {
                return NotFound();  
            }

            if (ModelState.IsValid)
            {
                
                existingFilm.name = film.name;
                existingFilm.description = film.description;
                existingFilm.price = film.price;

                return RedirectToAction(nameof(Index));  
            }

            return View(film); 
        }


        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);  
            if (film == null)
            {
                return NotFound(); 
            }
            return View(film);  
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var film = films.FirstOrDefault(x => x.Id == id);  
            if (film == null)
            {
                return NotFound(); 
            }

            films.Remove(film);  

            return RedirectToAction(nameof(Index));
        }
        
    }
}
