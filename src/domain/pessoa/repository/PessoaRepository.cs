using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.pessoa.models;
using apiotminesttocs.src.infra.data;
using apiotminesttocs.src.infra.interfaces.ipessoa;
using Microsoft.EntityFrameworkCore;

namespace apiotminesttocs.src.domain.pessoa.repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;
        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> findAll()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa?> findOne(int id)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> remove(int id)
        {
            var res = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            if (res == null) return false;

            _context.Pessoas.Remove(res);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Pessoa?> save(Pessoa request)
        {
            await _context.Pessoas.AddAsync(request);
            await _context.SaveChangesAsync();
            
            return await _context.Pessoas.FirstOrDefaultAsync(x => 
                x.Nome == request.Nome &&
                x.PasswordHash  == request.PasswordHash &&
                x.Email == request.Email &&
                x.CreatedAt == request.CreatedAt
            );
        }

        public async Task<Pessoa?> update(int id, Pessoa request)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == id);
            if (pessoa == null) return null;

            pessoa.Nome = request.Nome;
            pessoa.Email = request.Email;
            //x.PasswordHash == request.PasswordHash;

            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

    }
}