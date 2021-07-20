using DesafioTecnico.Data;
using DesafioTecnico.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Documento> GetId(int id)
        {

          return  await _context.Documentos.SingleOrDefaultAsync(x => x.Codigo == id);
        }
       public async Task<List<Documento>> GetAll()
        { 
            return await _context.Documentos.OrderBy(c => c.Titulo).AsNoTracking().ToListAsync();
           
        }

        public bool AnyId(int id)
        {
            return _context.Documentos.Any(e => e.Codigo == id);
        }
    }
}
