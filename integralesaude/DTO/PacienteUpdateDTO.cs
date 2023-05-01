using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integrale.Models;
using integralesaude.Enumerator;

namespace integralesaude.DTO
{
    public class PacienteUpdateDTO
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

        public PacienteUpdateDTO (PacientesModel paciente)
        {
            Id = paciente.Id;
            NomeCompleto = paciente.NomeCompleto;
            Genero = paciente.Genero;
            DataNascimento = paciente.DataNascimento;
            CPF = paciente.Cpf;
            Telefone = paciente.Telefone;
            ContatoEmergencia = paciente.ContatodeEmergencia;
            ListaAlergias = paciente.ListaAlergias;
            ListadeCuidadosEspecificos = paciente.ListadeCuidadosEspecificos;
            Convenio = paciente.Convenio;
            StatusAtendimento = paciente.StatusAtendimento; 
            TotaldeAtendimentos = paciente.TotaldeAtendimentos;


        }
    }
}