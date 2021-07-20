using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Repository
{
    public interface IRelatorioRepository <TEntity> where TEntity : class
    {
      Task Insert(TEntity entity);
      Task<TEntity> GetId(int id);
      Task<List<TEntity>> GetAll( );
      bool AnyId(int id);
    }
}
