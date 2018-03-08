using Clinica.Models;
using Clinica.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var vm = new AgendamentoViewModel
            {
                Medicos = _context.Medicos.ToList(),
                Pacientes = _context.Pacientes.ToList(),
                Data = DateTime.Now.ToShortDateString().ToString(),
                Hora = DateTime.Now.ToShortTimeString().ToString(),
                Heading = "Agendar Consulta",
                Botao = "Agendar"
            };
            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(AgendamentoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm = new AgendamentoViewModel
                {
                    Medicos = _context.Medicos.ToList(),
                    Pacientes = _context.Pacientes.ToList(),
                    Data = DateTime.Now.ToShortDateString().ToString(),
                    Hora = DateTime.Now.ToShortTimeString().ToString()
                };
                return View("Create", vm);
            }

            var agenda = new Agendamento
            {
                UsuarioId = User.Identity.GetUserId(),
                Data = vm.DateTime(),
                MedicoID = vm.Medico,
                PacienteID = vm.Paciente
            };

            _context.Agendamentos.Add(agenda);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var agenda = _context.Agendamentos.Single(x => x.ID == id);

            var vm = new AgendamentoViewModel
            {
                Id = id,
                Medicos = _context.Medicos.ToList(),
                Pacientes = _context.Pacientes.ToList(),
                Data = agenda.Data.ToString("dd/MM/yyyy"),
                Hora = agenda.Data.ToString("HH:mm"),
                Medico = agenda.MedicoID,
                Paciente = agenda.PacienteID,
                Heading = "Editar Consulta",
                Botao = "Editar"
            };
            ViewBag.Autenticado = User.Identity.IsAuthenticated;
            return View("Create", vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(AgendamentoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm = new AgendamentoViewModel
                {
                    Medicos = _context.Medicos.ToList(),
                    Pacientes = _context.Pacientes.ToList(),
                    Data = DateTime.Now.ToShortDateString().ToString(),
                    Hora = DateTime.Now.ToShortTimeString().ToString()
                };
                return View("Create", vm);
            }

            var agenda = _context.Agendamentos.Single(x => x.ID == vm.Id);

            agenda.UsuarioId = User.Identity.GetUserId();
            agenda.Data = vm.DateTime();
            agenda.MedicoID = vm.Medico;
            agenda.PacienteID = vm.Paciente;
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}