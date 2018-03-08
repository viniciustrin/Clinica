using Clinica.Models;
using Clinica.ViewModels;
using System.Linq;
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
            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            var vm = new MedicoViewModel
            {
                Medicos = _context.Medicos.Where(x => x.Deletado == false).ToList(),
                Heading = "Adicionar Médico",
                Botao = "Adicionar"
            };
            return View(vm);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(MedicoViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                vm.Medicos = _context.Medicos.Where(x => x.Deletado == false).ToList();
                vm.Heading = "Adicionar Médico";
                vm.Botao = "Adicionar";
                return View(vm);
            }

            var medico = new Medico
            {
                Nome = vm.Nome,
                Especialidade = vm.Especialidade
            };
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return RedirectToAction("Create", "Medico");

        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            var medico = _context.Medicos.Single(x => x.ID == id);

            var vm = new MedicoViewModel
            {
                Id = id,
                Medicos = _context.Medicos.Where(x => x.Deletado == false).ToList(),
                Nome = medico.Nome,
                Especialidade = medico.Especialidade,
                Heading = "Editar Médico",
                Botao = "Editar"
            };
            return View("Create",vm);
        }



        [Authorize]
        [HttpPost]
        public ActionResult Update(MedicoViewModel vm)
        {
            var medico = _context.Medicos.Single(x => x.ID == vm.Id);

            medico.Nome = vm.Nome;
            medico.Especialidade = vm.Especialidade;
            
            _context.SaveChanges();
            return RedirectToAction("Create", "Medico");

        }

    }
}