
using DesafioTecnico.Data;
using DesafioTecnico.Models;
using DesafioTecnico.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DesafioTecnico.Services
{

    public class RelatorioService : IRelatorioService  
    {
        private readonly DocumentContext _context;
        private readonly IRelatorioRepository<Documento> _repository;

        public RelatorioService(DocumentContext context, IRelatorioRepository<Documento> repository)
        {
            _context = context;
            _repository = repository;

        }

        

        public async Task<List<Documento>> GetRelatorios()
        {

            return await _context.Documentos.OrderBy(c => c.Titulo).AsNoTracking().ToListAsync();


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
         
         return  await _context.Documentos.SingleOrDefaultAsync(x => x.Codigo == id);


            

        }

       
    }
}
       
    

