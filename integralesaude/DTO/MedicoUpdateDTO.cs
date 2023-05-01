using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.Enumerator;
using integralesaude.Models;

namespace integralesaude.DTO
{
    public class MedicoUpdateDTO

    {
        public int Id {get; set;}
        public string NomeCompleto {get; set;}

        public string CPF {get; set;}

        public DateTime DataNascimento {get; set;}

        public string Telefone {get; set;}


        public string Genero {get; set;}
        public string InstituicaodeEnsino {get; set;}
       
        public string CRM {get; set;}

        public EspecializacaoClinicaEnum EspecializacaoClinica {get; set;}
        
        public EstadonoSistemaEnum EstadonoSistema {get;set;}
        
        public int TotaldeAtendimentos {get; set;} 

        public int Identificador {get; set;}

        public int Atendimentos {get; set;}

    
    
     public MedicoUpdateDTO (MedicosModel medicosModel) 
        {
            NomeCompleto = medicosModel.NomeCompleto;
            Genero = medicosModel.Genero;
            DataNascimento = medicosModel.DataNascimento;
            CPF = medicosModel.Cpf;
            Telefone = medicosModel.Telefone;
            Id = medicosModel.Id;
            InstituicaodeEnsino = medicosModel.InstituicaodeEnsino;
            CRM = medicosModel.CRM;
            EspecializacaoClinica = medicosModel.EspecializacaoClinica;
            EstadonoSistema = medicosModel.EstadonoSistema;
            TotaldeAtendimentos = medicosModel.TotaldeAtendimentos;
            Identificador = medicosModel.Id;
            Atendimentos = medicosModel.TotaldeAtendimentos;
        }
    }
}
