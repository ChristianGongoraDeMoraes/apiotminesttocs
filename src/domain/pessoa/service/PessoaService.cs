using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.pessoa.dto;
using apiotminesttocs.src.domain.pessoa.models;
using apiotminesttocs.src.domain.pessoa.mapper;
using apiotminesttocs.src.infra.interfaces.ipessoa;

namespace apiotminesttocs.src.domain.pessoa.service
{
    public class PessoaService
    {
        public readonly IPessoaRepository _pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<Pessoa?> save(SavePessoaRequestDto request)
        {
            var reqPessoa = request.SaveToEntity();

            var result = await _pessoaRepository.save(reqPessoa);
            if (result == null) return null;

            return result;
        }

        public async Task<List<Pessoa>> findAll()
        {
            return await _pessoaRepository.findAll();
        }

        public async Task<Pessoa?> findOne(int id)
        {
            var result = await _pessoaRepository.findOne(id);
            if (result == null) return null;

            return result;
        }

        public async Task<bool> remove(int id)
        {
            var result = await _pessoaRepository.remove(id);
            if (result == false) return false;
            return true;
        }

        public async Task<Pessoa?> update(int id, UpdatePessoaRequestDto request)
        {
            var reqRecado = request.UpdateToEntity();

            var result = await _pessoaRepository.update(id, reqRecado);
            if (result == null) return null;
            return result;
        }
    }
}