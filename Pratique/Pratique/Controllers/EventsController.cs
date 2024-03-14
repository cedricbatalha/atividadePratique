using Pratique.Entities;
using Pratique.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Pratique.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsDBContext _context;

        public EventsController(EventsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           
            // retornar lista em que os eventos não estejam cancelados
            var Events = _context.Events.Where(d => d.Ativo).ToList();

            return Ok(Events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            // retornar lista em que os eventos não estejam cancelados
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Ok(Event);
        }

        [HttpPost]
        public IActionResult Post(Event Event)
        {
            _context.Events.Add(Event);

            return CreatedAtAction(nameof(GetById), new { id = Event.Id }, Event);
        }

        // api/dev-events/4324324 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Event input)
        {
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            Event.Update(input.NomeEvento, input.DescricaoEvento, input.DataInicio, input.DataFim);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            Event.Delete();

            return NoContent();
        }

        [HttpPost("{id}/incritos")]

        public IActionResult PostIncrito(Guid id, EventInscrito incrito)
        {
            var Event = _context.Events.SingleOrDefault(d => d.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            Event.Inscritos.Add(incrito);

            return NoContent();
        }
    }
}
