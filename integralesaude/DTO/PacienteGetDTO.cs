using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.Enumerator;

namespace integralesaude.DTO
{
    public class PacienteGetDTO
    {
        public string NomeCompleto { get; set; }
        public int Id {get; set;}
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }        
        public string ContatoEmergencia { get; set; }      
        public string ListaAlergias {get; set; }       
        public string ListadeCuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public int TotaldeAtendimentos {get; set;}
        public StatusAtendimentoEnum StatusAtendimento { get; set; }

    }
}