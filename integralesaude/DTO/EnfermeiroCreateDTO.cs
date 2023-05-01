using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace integralesaude.DTO
{
    public class EnfermeiroCreateDTO
    {
        public string NomeCompleto {get; set;}

        public string Genero {get; set;}

        public string Telefone {get; set;}

        public DateTime DataNascimento{ get; set;}

        public string CPF {get; set;}
        public string InstituicaodeEnsino {get; set;}
        public string COFEN {get; set;}
        
    }
}