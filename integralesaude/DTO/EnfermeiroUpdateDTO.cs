using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.Models;

namespace integralesaude.DTO
{
    public class EnfermeiroUpdateDTO
    {
        public int Id { get; set;}
        public string NomeCompleto {get; set;}
        public string CPF {get; set;}

        public string Telefone {get; set;}

        public DateTime DataNascimento {get; set;}

        public string Genero {get; set;}

        public string InstituicaodeEnsino {get; set;}
        public string COFEN {get; set;}

        public EnfermeiroUpdateDTO(EnfermeirosModel enfermeirosModel) 
        {
            NomeCompleto = enfermeirosModel.NomeCompleto;
            Genero = enfermeirosModel.Genero;
            DataNascimento = enfermeirosModel.DataNascimento;
            CPF = enfermeirosModel.Cpf;
            Telefone = enfermeirosModel.Telefone;
            Id = enfermeirosModel.Id;
            InstituicaodeEnsino = enfermeirosModel.InstituicaodeEnsino;
            COFEN = enfermeirosModel.COFEN;
        }
        
    }
}