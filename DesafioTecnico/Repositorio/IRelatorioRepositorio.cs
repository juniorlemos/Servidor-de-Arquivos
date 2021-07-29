using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Repository
{
    public interface IRelatorioRepositorio <TEntity> where TEntity : class
    {
      Task InserirDocumento(TEntity entidade);
      Task<TEntity> ObterDocumento(int id);
      Task<List<TEntity>> ObterTodosDocumentos( );
      bool DocumentoExiste(int id);
    }
}
