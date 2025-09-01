using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.recados.models;
using apiotminesttocs.src.domain.recados.service;
using Microsoft.AspNetCore.Mvc;

namespace apiotminesttocs.src.domain.recados.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecadoController : ControllerBase
    {
        public readonly RecadoService _recadoService;
        public RecadoController(RecadoService recadoService)
        {
            _recadoService = recadoService;
        }

         // POST: api/recados
        [HttpPost]
        public async Task<ActionResult<Recado>> Create([FromBody] Recado recado)
        {
            var saved = await _recadoService.save(recado);
            return CreatedAtAction(nameof(GetById), new { id = saved?.Id }, saved);
        }

        // GET: api/recados
        [HttpGet]
        public async Task<ActionResult<List<Recado>>> GetAll()
        {
            var recados = await _recadoService.findAll();
            return Ok(recados);
        }

        // GET: api/recados/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Recado>> GetById(int id)
        {
            var recado = await _recadoService.findOne(id);
            if (recado == null)
                return NotFound();

            return Ok(recado);
        }

        // PUT: api/recados/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Recado>> Update(int id, [FromBody] Recado request)
        {
            var updated = await _recadoService.update(id, request);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/recados/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _recadoService.remove(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}