using Clinica.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Index()
        {
            var proximosAgendamentos = _context.Agendamentos
                .Include(m => m.Usuario)
                .Include(x => x.Medico)
                .Include(y => y.Paciente)
                .Where(d => d.Data > DateTime.Now && d.Cancelado == false);

            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            return View(proximosAgendamentos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}