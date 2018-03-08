using Clinica.Models;
using Clinica.ViewModels;
using System.Linq;
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
            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            var vm = new PacienteViewModel
            {
                Pacientes = _context.Pacientes.Where(x => x.Deletado == false).ToList(),
                Heading = "Adicionar Paciente",
                Botao = "Adicionar"
                
            };
            return View(vm);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(PacienteViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Pacientes = _context.Pacientes.Where(x => x.Deletado == false).ToList();
                vm.Heading = "Adicionar Paciente";
                vm.Botao = "Adicionar";
                return View(vm);
            }


            var paciente = new Paciente
            {
                Nome = vm.Nome,
                Endereco = vm.Endereco,
                RG = vm.RG
            };
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            return RedirectToAction("Create", "Paciente");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            var paciente = _context.Pacientes.Single(x => x.Id == id);
            var vm = new PacienteViewModel
            {
                Id = id,
                Nome = paciente.Nome,
                Endereco = paciente.Endereco,
                RG = paciente.RG,
                Pacientes = _context.Pacientes.Where(x => x.Deletado == false).ToList(),
                Heading = "Editar Paciente",
                Botao = "Editar"
            };
            return View("Create", vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(PacienteViewModel vm)
        {
            var paciente = _context.Pacientes.Single(x => x.Id == vm.Id);

            paciente.Nome = vm.Nome;
            paciente.Endereco = vm.Endereco;
            paciente.RG = vm.RG;

            _context.SaveChanges();

            return RedirectToAction("Create", "Paciente");
        }
    }
}