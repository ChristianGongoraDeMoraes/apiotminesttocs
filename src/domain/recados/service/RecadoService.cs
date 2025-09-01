using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.recados.mapper;
using apiotminesttocs.src.domain.recados.dto;
using apiotminesttocs.src.domain.recados.models;
using apiotminesttocs.src.domain.recados.repository;
using apiotminesttocs.src.infra.interfaces.irecados.irepository;

namespace apiotminesttocs.src.domain.recados.service
{
    public class RecadoService
    {
        public readonly IRecadoRepository _recadoRepository;
        public RecadoService(IRecadoRepository recadoRepository)
        {
            _recadoRepository = recadoRepository;
        }

        public Task<Recado?> save(SaveRecadoRequestDto request)
        {
            var reqRecado = request.SaveToEntity();

            return _recadoRepository.save(reqRecado);
        }

        public async Task<List<Recado>> findAll()
        {
            return await _recadoRepository.findAll();
        }

        public async Task<Recado?> findOne(int id)
        {
            var result = await _recadoRepository.findOne(id);
            if (result == null) return null;

            return result;
        }

        public async Task<bool> remove(int id)
        {
            var result = await _recadoRepository.remove(id);
            if (result == false) return false;
            return true;
        }

        public async Task<Recado?> update(int id, UpdateRecadoRequestDto request)
        {
            var reqRecado = request.UpdateToEntity();

            var result = await _recadoRepository.update(id, reqRecado);
            if (result == null) return null;
            return result;
        }
    }
}