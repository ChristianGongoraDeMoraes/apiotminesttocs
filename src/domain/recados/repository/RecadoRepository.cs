using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.recados.dto;

using apiotminesttocs.src.domain.recados.models;
using apiotminesttocs.src.infra.data;
using apiotminesttocs.src.infra.interfaces.irecados.irepository;
using Microsoft.EntityFrameworkCore;

namespace apiotminesttocs.src.domain.recados.repository
{
    public class RecadoRepository : IRecadoRepository
    {
        public readonly ApplicationDbContext _context;
        public RecadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Recado>> findAll()
        {
            return await _context.Recados
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .ToListAsync();
        }

        public async Task<Recado?> findOne(int id)
        {
            return await _context.Recados
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> remove(int id)
        {
            var recado = await _context.Recados.FirstOrDefaultAsync(x => x.Id == id);
            if (recado == null) return false;

            _context.Recados.Remove(recado);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Recado?> save(Recado request)
        {
            var sender = _context.Pessoas.FirstOrDefault(x => x.Id == request.SenderId);
            var receiver = _context.Pessoas.FirstOrDefault(x => x.Id == request.ReceiverId);
            if (sender == null || receiver == null) return null;
            request.Sender = sender;
            request.Receiver = receiver;

            await _context.Recados.AddAsync(request);
            await _context.SaveChangesAsync();
            
            return await _context.Recados.FirstOrDefaultAsync(x => 
                x.Texto == request.Texto &&
                x.SenderId == request.SenderId &&
                x.ReceiverId == request.ReceiverId &&
                x.Data == request.Data
            );
        }

        public async Task<Recado?> update(int id, Recado request)
        {
            var recado = await _context.Recados.FirstOrDefaultAsync(x => x.Id == id);
            if (recado == null) return null;

            recado.Texto = request.Texto;
            recado.Lido = request.Lido;

            _context.Recados.Update(recado);
            await _context.SaveChangesAsync();

            return recado;
        }
    }
}