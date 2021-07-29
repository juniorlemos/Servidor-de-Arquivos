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
        
        private readonly IRelatorioRepositorio<Documento> _repositorio;

        public RelatorioService( IRelatorioRepositorio<Documento> repositorio)
        {
            
            _repositorio = repositorio;
        }


        public async Task<List<Documento>> ObterTodosDocumentos()
        {

            return await _repositorio.ObterTodosDocumentos();

        }

        public async Task InserirDocumento(Documento documento, IFormFile arquivo)
        {          
                using (var memoria = new MemoryStream())
                {
                    arquivo.CopyTo(memoria);
                    documento.Arquivo = memoria.ToArray();
                }

                await _repositorio.InserirDocumento(documento);

        }
        public async Task<Documento> ObterDocumento(int id)
        {

            return await _repositorio.ObterDocumento(id);        

        }

        public bool DocumentoExiste(int id)
        {
           return _repositorio.DocumentoExiste(id);
        }
    }
}
       
    

