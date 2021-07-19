using DesafioTecnico.Data;
using DesafioTecnico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Repository
{
    public class RelatorioRepository : IRelatorioRepository<Documento>
    {
        private readonly DocumentContext _context;
        public RelatorioRepository(DocumentContext context)
        {
            _context = context;
        }

        public async Task Insert(Documento entity)
        {
            _context.Add(entity);

            await _context.SaveChangesAsync();
        }
    }
}
