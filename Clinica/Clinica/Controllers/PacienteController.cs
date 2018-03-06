using Clinica.Models;
using Clinica.ViewModels;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PacienteController()
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
        public ActionResult Create(PacienteViewModel vm)
        {
            var paciente = new Paciente
            {
                Nome = vm.Nome,
                Endereco = vm.Endereco,
                RG = vm.RG
            };
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}