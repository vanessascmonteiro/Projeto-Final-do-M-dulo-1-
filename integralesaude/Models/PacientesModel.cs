using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using integralesaude.Models;
using integralesaude.Enumerator;

namespace integrale.Models
{
    [Table("Pacientes")]
    public class PacientesModel : Pessoa
    {
        [Column("ContatodeEmergencia")]
        [MaxLength(100)]
        public string ContatodeEmergencia {get; set;}
        
        [Column("Lista de Alergias")]
        [MaxLength]
        public string ListaAlergias {get; set;}

        [Column("Lista de Cuidados Específicos")]
        public string ListadeCuidadosEspecificos {get; set;}
        
        [Column("Convênio")]
        public string Convenio {get; set;}

        [Column("Status de Atendimento")]
        public StatusAtendimentoEnum StatusAtendimento {get; set;}

        [Column("Total de Atendimentos")]
        public int TotaldeAtendimentos {get; set;}
     
        }
}