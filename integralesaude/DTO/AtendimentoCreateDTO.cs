using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.Enumerator;

namespace integralesaude.DTO
{
    public class AtendimentoCreateDTO
    {
    public StatusAtendimentoEnum StatusAtendimento {get; set;}
    public int AtendimentosRealizados {get; set;}

    public int IdMedico {get; set;}
    public int IdPaciente {get; set;}
    


    }
}