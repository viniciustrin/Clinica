using Clinica.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinica.ViewModels
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string RG { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public string Heading { get; set; }
        public string Botao { get; set; }
        public string Action {
            get
            {
                return (Id != 0) ? "Update" : "Create";
            }
        }
    }
}