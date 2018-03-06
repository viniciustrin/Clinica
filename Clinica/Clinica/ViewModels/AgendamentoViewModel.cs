using Clinica.Models;
using System;
using System.Collections.Generic;

namespace Clinica.ViewModels
{
    public class AgendamentoViewModel
    {
        public ApplicationUser Usuario { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }

        public DateTime DateTime
        {
            get { return DateTime.Parse(string.Format("{0} {1}", Data, Hora)); }


        }
        public int Paciente { get; set; }
        public IEnumerable<Paciente > Pacientes { get; set; }
        public int Medico { get; set; }
        public IEnumerable<Medico> Medicos{ get; set; }
    }
}