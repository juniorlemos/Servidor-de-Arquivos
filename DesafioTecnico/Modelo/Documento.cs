using System;
using System.ComponentModel.DataAnnotations;


namespace DesafioTecnico.Models
{
    public class Documento 
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        [Range(1, 2147483647, ErrorMessage = "Por favor escolha um número entre 1 a 2147483647 ")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Por favor informe um número positivo")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        [Display(Name = "Título")]
        [StringLength(50, MinimumLength = 4, ErrorMessage =
            "O Título deve ter no mínimo 4 e no máximo 50 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        [StringLength(30, MinimumLength = 4, ErrorMessage =
            "O Processo deve ter no mínimo 4 e no máximo 30 caracteres.")]
        public string Processo { get; set; }

        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        [StringLength(30, MinimumLength = 4, ErrorMessage =
            "A Categoria deve ter no mínimo 4 e no máximo 30 caracteres.")]
        public string Categoria { get; set; }
       
        public byte[] Arquivo { get; set; }

       
        public string NomeArquivo { get; set; }
       
        
        
    }
}
