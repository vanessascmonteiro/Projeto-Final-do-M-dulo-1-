using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using integrale.Models;

namespace integralesaude.Models
{
    [Table ("Atendimento Médico")] 

    public class AtendimentoModel
    {
        
        public int id {get; set;}
        [Column("idPaciente")]
        [ForeignKey("IdPaciente")]
        public int pacienteModelId {get; set;}
        public PacientesModel pacientesModel {get; set;}

        [Column ("idMedico")]
        [ForeignKey("IdMedico")]
        public int medicoModelId {get; set;}
        public MedicosModel medicosModel {get; set;}
        



        
    }
}