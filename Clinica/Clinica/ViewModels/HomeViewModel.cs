using Clinica.Models;
using System.Collections.Generic;

namespace Clinica.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Agendamento> Agendamentos { get; set; }
        public bool Autenticado { get; set; }
    }
}