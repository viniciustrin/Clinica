using Clinica.Models;
using System.Linq;
using System.Web.Http;

namespace Clinica.Api
{
    public class AgendamentoController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public AgendamentoController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var agenda = _context.Agendamentos.Single(x => x.ID == id);
            agenda.Cancelado = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
