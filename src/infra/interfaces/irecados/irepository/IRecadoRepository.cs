using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.recados.models;

namespace apiotminesttocs.src.infra.interfaces.irecados.irepository
{
    public interface IRecadoRepository
    {
        Task<Recado?> findOne(int id);
        Task<List<Recado>> findAll();
        Task<Recado?> update(int id, Recado request);
        Task<bool> remove(int id);
        Task<Recado?> save(Recado request);
    }
}