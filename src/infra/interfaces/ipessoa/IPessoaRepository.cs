using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.pessoa.models;

namespace apiotminesttocs.src.infra.interfaces.ipessoa
{
    public interface IPessoaRepository
    {
        Task<Pessoa?> findOne(int id);
        Task<List<Pessoa>> findAll();
        Task<Pessoa?> update(int id, Pessoa request);
        Task<bool> remove(int id);
        Task<Pessoa?> save(Pessoa request);
        Task<Pessoa?> login(Pessoa request);
    }
}