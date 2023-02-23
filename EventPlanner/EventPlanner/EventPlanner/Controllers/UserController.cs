using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using EventPlannerModels;

namespace EventPlanner.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            EventPlannerContext context = new EventPlannerContext();
            List<TipoUsuario> tipoUsuarios = context.TipoUsuarios.ToList<TipoUsuario>();
            ViewBag.TipoUsuario = tipoUsuarios;
            return View();
        }
        public IActionResult List()
        {
            EventPlannerContext context = new EventPlannerContext();
            List<Usuario> usuarios = context.Usuarios.ToList<Usuario>();
            return View(usuarios);
        }
        [HttpPost]
        public IActionResult Create(string Nombre, string Contrasenia, int TipoUsuario)
        {
            EventPlannerContext context = new EventPlannerContext();
            Usuario usuario = new Usuario
            {
                Nombre = Nombre,
                Contrasenia = Contrasenia,
               TipoUsuario = TipoUsuario
            };
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return View();
        }
    }
}
