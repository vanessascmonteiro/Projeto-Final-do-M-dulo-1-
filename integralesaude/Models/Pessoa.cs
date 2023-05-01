using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace integralesaude.Models
{
    
    public class Pessoa
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Column ("Id")]
      public int Id {get; set;}

      [MaxLength (100)]
      public string NomeCompleto {get; set;}
      public string Genero {get; set;}
      public DateTime DataNascimento {get; set;}
      public string Cpf {get; set;}
      public string Telefone {get; set;}
      
            
    }
}