using DesafioTecnico.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Data
{
    public class DocumentContext : DbContext
    {

        public DocumentContext(DbContextOptions<DocumentContext>options) : base(options)
        {
                
        }
        public DbSet<Documento> Documentos { get; set; }

    }
}
