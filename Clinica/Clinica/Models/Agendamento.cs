using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Agendamento
    {
        public int ID { get; set; }
        public ApplicationUser Usuario { get; set; }
        [Required]
        public string UsuarioId { get; set; }
        [Required]
        public DateTime Data { get; set; }        
        public Paciente Paciente { get; set; }
        [Required]
        public int  PacienteID { get; set; }
        
        public Medico Medico { get; set; }
        [Required]
        public int MedicoID { get; set; }
    }
}