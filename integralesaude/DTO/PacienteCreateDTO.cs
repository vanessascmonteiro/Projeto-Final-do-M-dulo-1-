using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.Enumerator;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class PacienteCreateDTO
    {
       
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O contato de emergência é obrigatório")]
        public string ContatoEmergencia { get; set; }
      
        public string ListaAlergias {get; set; }
       
        public string ListadeCuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public int TotaldeAtendimentos {get; set;}
        public StatusAtendimentoEnum StatusAtendimento { get; set; }

          
    }
}