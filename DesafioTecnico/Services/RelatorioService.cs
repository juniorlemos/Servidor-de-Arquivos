using DesafioTecnico.Models;
using DesafioTecnico.Repository;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesafioTecnico.Services
{

    public class RelatorioService : IRelatorioService  
    {
        
        private readonly IRelatorioRepository<Documento> _repository;

        public RelatorioService( IRelatorioRepository<Documento> repository)
        {
            
            _repository = repository;
        }


        public async Task<List<Documento>> GetRelatorios()
        {

            return await _repository.GetAll();

        }

        public async Task PostRelatorio(Documento documento, IFormFile file)
        {          
                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    documento.Arquivo = target.ToArray();
                }

                await _repository.Insert(documento);

        }
        public async Task<Documento> DownloadRelatorio(int id)
        {

            return await _repository.GetId(id);        

        }

        public bool DocumentoExiste(int id)
        {
           return _repository.AnyId(id);
        }
    }
}
       
    

