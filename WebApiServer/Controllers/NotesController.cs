﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly NoteService _noteService;

        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<List<Note>> Get() =>
            _noteService.Get();

        [HttpGet("{id:length(24)}", Name = "GetNote")]
        public ActionResult<Note> Get(string id)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPost]
        public ActionResult<Note> Create(Note note)
        {
            _noteService.Create(note);

            return CreatedAtRoute("GetNote", new { id = note.Id.ToString() }, note);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Note noteIn)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _noteService.Update(id, noteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _noteService.Remove(note);

            return NoContent();
        }
    }
}
