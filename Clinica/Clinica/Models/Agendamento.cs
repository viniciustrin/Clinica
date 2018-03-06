using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Agendamento
    {
        public int ID { get; set; }
        [Required]
        public ApplicationUser Usuario { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public Paciente Paciente { get; set; }
        [Required]
        public Medico Medico { get; set; }
    }
}