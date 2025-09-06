using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.pessoa.dto;
using apiotminesttocs.src.domain.pessoa.models;
using apiotminesttocs.src.domain.pessoa.service;
using Microsoft.AspNetCore.Mvc;

namespace apiotminesttocs.src.domain.pessoa.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        /// Cria uma nova pessoa
        [HttpPost]
        public async Task<ActionResult<Pessoa>> Save([FromBody] SavePessoaRequestDto request)
        {
            var pessoa = await _pessoaService.save(request);
            if (pessoa == null) return BadRequest("Erro ao salvar pessoa.");

            return CreatedAtAction(nameof(FindOne), new { id = pessoa.Id }, pessoa);
        }

        /// Retorna todas as pessoas
        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> FindAll()
        {
            var pessoas = await _pessoaService.findAll();
            return Ok(pessoas);
        }

        /// Retorna uma pessoa por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pessoa>> FindOne(int id)
        {
            var pessoa = await _pessoaService.findOne(id);
            if (pessoa == null) return NotFound("Pessoa não encontrada.");

            return Ok(pessoa);
        }

        /// Remove uma pessoa por ID
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var deleted = await _pessoaService.remove(id);
            if (!deleted) return NotFound("Pessoa não encontrada.");

            return NoContent();
        }

        /// Atualiza uma pessoa por ID
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Pessoa>> Update(int id, [FromBody] UpdatePessoaRequestDto request)
        {
            var pessoa = await _pessoaService.update(id, request);
            if (pessoa == null) return NotFound("Pessoa não encontrada para atualização.");

            return Ok(pessoa);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Pessoa>> Login([FromBody] LoginRequestDto request)
        {
            var pessoa = await _pessoaService.Login(request);
            if (pessoa == null) return NotFound();
            
            return Ok(pessoa);
        }
    }
}