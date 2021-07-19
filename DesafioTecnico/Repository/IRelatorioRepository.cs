using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Repository
{
    public interface IRelatorioRepository <TEntity> where TEntity : class
    {
      Task Insert(TEntity entity);
    }
}
