using EventPlannerModels;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult List()
        {
            EventPlannerContext context = new EventPlannerContext();
            List<Categorium> categoria = context.Categoria.ToList();
            return View(categoria);
        }
        [HttpPost]
        public IActionResult Create(string Nombre)
        {
            EventPlannerContext context = new EventPlannerContext();
            Categorium categorium = new Categorium
            {
                Nombre = Nombre,
            };
            context.Categoria.Add(categorium);
            context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EventPlannerContext context = new EventPlannerContext();
            Categorium categorium = context.Categoria.Where(category => category.Id.Equals(id)).First();
            context.Categoria.Remove(categorium);
            context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var context = new EventPlannerContext();
            Categorium categorium = context.Categoria.Where(category => category.Id.Equals(id)).First();
            return View(categorium);
        }
        [HttpPost]
        public IActionResult Edit(int id, string Nombre)
        {
            EventPlannerContext context = new EventPlannerContext();
            Categorium categorium = context.Categoria.Where(category => category.Id.Equals(id)).First();
            categorium.Nombre = Nombre;
            context.Categoria.Update(categorium);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
