using Clinica.Models;
using Clinica.ViewModels;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class MedicoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MedicoController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {            

            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(MedicoViewModel vm)
        {
            //var usuario = _context.Users.Single(u => u.Id == User.Identity.GetUserId());

            var medico = new Medico
            {
                Nome = vm.Nome,
                Especialidade = vm.Especialidade
            };
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}