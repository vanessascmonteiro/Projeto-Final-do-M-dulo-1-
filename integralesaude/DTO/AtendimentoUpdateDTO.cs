using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integrale.Models;
using integralesaude.Enumerator;
using integralesaude.Models;

namespace integralesaude.DTO
{
    public class AtendimentoUpdateDTO
    {
        public MedicosModel Medico {get; set;}
        public PacientesModel Paciente {get; set;}
        public StatusAtendimentoEnum StatusAtentimento {get; set;}

        public AtendimentoUpdateDTO(MedicosModel medico, PacientesModel paciente)

        {
           Medico = medico;
           Paciente = paciente;
        }


    }
}