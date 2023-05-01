using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.Enumerator;

namespace integralesaude.DTO
{
    public class MedicoGetDTO
    {
        public string NomeCompleto {get; set;}

        public int Id {get; set;}
        public string InstituicaodeEnsino {get; set;}
       
        public string CRM {get; set;}

        public EspecializacaoClinicaEnum EspecializacaoClinica {get; set;}
        
        public EstadonoSistemaEnum EstadonoSistema {get;set;}
        
        public int TotaldeAtendimentos {get; set;} 
    }
}