using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string RG { get; set; }
        public bool Deletado { get; set; }
    }
}