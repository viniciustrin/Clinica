using Clinica.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Clinica.Api
{
    public class MedicoController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MedicoController()
        {
            _context = new ApplicationDbContext();
        }

        [AllowAnonymous]        
        public HttpResponseMessage Get()
        {
            var medicos = _context.Medicos.Select(c => new MedicoDTO()
            {
                ID = c.ID,
                Nome = c.Nome,
                Especialidade = c.Especialidade,
                Deletado = c.Deletado
            });


            return this.Request.CreateResponse(HttpStatusCode.OK, medicos);

        }


        [Authorize]
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var medico = _context.Medicos.Single(x => x.ID == id);
            medico.Deletado = true;
            _context.SaveChanges();

            return Ok();
        }
    }

    public class MedicoDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public bool Deletado { get; set; }
    }
}
