using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace integralesaude.DTO
{
    public class StatusAtendimentoDTO
    {
        [Required(ErrorMessage = "Obrigatório informar o status.")]
        public string Status { get; set; }
    }
}