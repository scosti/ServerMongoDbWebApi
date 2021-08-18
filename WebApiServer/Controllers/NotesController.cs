using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApp.Models;
using WebApiServer.Services;

namespace WebApiServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteServices _crudService;

        public NotesController(NoteServices noteService)
        {
            _crudService = noteService;
        }

        [HttpGet]
        public ActionResult<List<Note>> Get() =>
            _crudService.Get();

        [HttpGet("{name}", Name = "GetNote")]
        public ActionResult<Note> Get(string name)
        {
            var note = _crudService.Get(name);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPost]
        public ActionResult<Note> Create(Note note)
        {
            _crudService.Create(note);

            return CreatedAtRoute("GetNote", new { id = note.Id.ToString() }, note);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Note noteIn)
        {
            var note = _crudService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _crudService.Update(id, noteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var note = _crudService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _crudService.Remove(note);

            return NoContent();
        }
    }
}
