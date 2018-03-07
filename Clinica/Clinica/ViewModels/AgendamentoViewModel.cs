using Clinica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinica.ViewModels
{
    public class AgendamentoViewModel
    {
        public ApplicationUser Usuario { get; set; }
        [Required]
        [FutureDate]
        public string Data { get; set; }
        [Required]
        [ValidTime]
        public string Hora { get; set; }
        public DateTime DateTime()
        {
            return System.DateTime.Parse(string.Format("{0} {1}", Data, Hora));
        }
        [Required]
        public int Paciente { get; set; }
        public IEnumerable<Paciente > Pacientes { get; set; }
        [Required]
        public int Medico { get; set; }
        public IEnumerable<Medico> Medicos{ get; set; }
    }
}