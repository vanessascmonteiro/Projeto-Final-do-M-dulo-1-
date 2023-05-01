using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace integralesaude.Models
{
    [Table("Enfermeiros")]
    public class EnfermeirosModel : Pessoa
    {
        [Column ("Instituição de Ensino")]
        public string InstituicaodeEnsino {get; set;}
        [Column ("COFEN")]
        public string COFEN {get; set;}
        
    }
}