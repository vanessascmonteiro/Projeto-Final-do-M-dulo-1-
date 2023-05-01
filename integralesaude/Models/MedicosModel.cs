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

namespace integralesaude.Models
{
    [Table("Medicos")]
    public class MedicosModel : Pessoa
    {
        [Column ("Instituição de Ensino")]
        public string InstituicaodeEnsino {get; set;}
        [Column ("CRM")]
        public string CRM {get; set;}

        [Column ("Especialização Clínica")]
        public EspecializacaoClinicaEnum EspecializacaoClinica {get; set;}
        
        [Column ("Estado no Sistema")]
        public EstadonoSistemaEnum EstadonoSistema {get;set;}
        
        [Column ("Total de Atendimentos")]
        public int TotaldeAtendimentos {get; set;} 

    }
}