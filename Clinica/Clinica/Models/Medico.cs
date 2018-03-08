using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class Medico
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Especialidade { get; set; }
        public bool Deletado { get; set; }
    }
}