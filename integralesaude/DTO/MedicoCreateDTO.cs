using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.Enumerator;

namespace integralesaude.DTO
{
    public class MedicoCreateDTO
    {
        public string CPF {get; set;}

        public string NomeCompleto {get; set;}

        public DateTime DataNascimento {get; set;}
        public string InstituicaodeEnsino {get; set;}

        public string Genero {get; set;}
       
        public string CRM {get; set;}

        public string Telefone {get; set;}

        public EspecializacaoClinicaEnum EspecializacaoClinica {get; set;}
        
        public EstadonoSistemaEnum EstadonoSistema {get;set;}
        
        public int TotaldeAtendimentos {get; set;} 

    }
}