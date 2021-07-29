using DesafioTecnico.Data;
using DesafioTecnico.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Repository
{
    public class RelatorioRepositorio : IRelatorioRepositorio<Documento>
    {
        private readonly DocumentoContexto _contexto;
        public RelatorioRepositorio(DocumentoContexto contexto)
        {
            _contexto = contexto;
        }
        public async Task InserirDocumento(Documento entidade)
        {          
                _contexto.Add(entidade);

                await _contexto.SaveChangesAsync();           
        }
        public async Task<Documento> ObterDocumento(int id)
        {

          return  await _contexto.Documentos.SingleOrDefaultAsync(x => x.Codigo == id);
        }
       public async Task<List<Documento>> ObterTodosDocumentos()
        { 
            return await _contexto.Documentos.OrderBy(c => c.Titulo).AsNoTracking().ToListAsync();
           
        }

        public bool DocumentoExiste(int id)
        {
            return _contexto.Documentos.Any(e => e.Codigo == id);
        }
    }
}
