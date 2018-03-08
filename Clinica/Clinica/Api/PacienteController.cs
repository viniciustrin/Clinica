using Clinica.Models;
using System.Linq;
using System.Web.Http;

namespace Clinica.Api
{
    public class PacienteController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PacienteController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var paciente = _context.Pacientes.Single(x => x.Id == id);
            paciente.Deletado = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
