using EventPlannerModels;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers
{
    public class UserTypeController : Controller
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
            List<TipoUsuario> tipoUsuarios = context.TipoUsuarios.ToList<TipoUsuario>();
            return View(tipoUsuarios);
        }
        [HttpPost]
        public IActionResult Create(string Descripcion)
        {
            EventPlannerContext context = new EventPlannerContext();
            TipoUsuario tipoUsuario = new TipoUsuario
            {
                Descripcion = Descripcion,
            };
            context.TipoUsuarios.Add(tipoUsuario);
            context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EventPlannerContext context = new EventPlannerContext();
            TipoUsuario tipoUsuario = context.TipoUsuarios.Where(tipoUsuario => tipoUsuario.Id.Equals(id)).First();
            context.TipoUsuarios.Remove(tipoUsuario);
            context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var context = new EventPlannerContext();
            TipoUsuario tipoUsuario = context.TipoUsuarios.Where(tipoUsuario => tipoUsuario.Id.Equals(id)).First();
            return View(tipoUsuario);
        }
        [HttpPost]
        public IActionResult Edit(int id, string Descripcion)
        {
            EventPlannerContext context = new EventPlannerContext();
            TipoUsuario tipoUsuario = context.TipoUsuarios.Where(tipoUsuario => tipoUsuario.Id.Equals(id)).First();
            tipoUsuario.Descripcion = Descripcion;
            context.TipoUsuarios.Update(tipoUsuario);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
