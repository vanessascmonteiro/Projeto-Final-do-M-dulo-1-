using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.DTO;
using integralesaude.Enumerator;
using integralesaude.Models;
using Microsoft.AspNetCore.Mvc;

namespace integralesaude.Controllers
{
    public class AtendimentoController
    {
        private readonly LabMedicineContext labMedicineContext;
        public AtendimentoController (LabMedicineContext labMedicineContext)
        {
            this.labMedicineContext = labMedicineContext;
        }
        [HttpPut("/atendimentos")]
        public ActionResult<AtendimentoUpdateDTO> Put(LabMedicineContext labMedicineContext, [FromBody]AtendimentoCreateDTO atendimentoCreateDTO)
        {
           var pacienteModel = labMedicineContext.Pacientes.FirstOrDefault(p => p.Id == atendimentoCreateDTO.IdPaciente);
           if(pacienteModel == null) 
           {
            return NotFound("Paciente não encontrado no sistema.");
           }

           var medicoModel = labMedicineContext.Medicos.FirstOrDefault(m => m.Id == atendimentoCreateDTO.IdMedico);
           if(medicoModel == null) {
            return NotFound("Medico não encontradono sistema.");
           }

            pacienteModel.StatusAtendimento = StatusAtendimentoEnum.Atendido;
            pacienteModel.TotaldeAtendimentos++;

            medicoModel.TotaldeAtendimentos = medicoModel.TotaldeAtendimentos++;
           
            labMedicineContext.Medicos.Update(medicoModel);
            labMedicineContext.Pacientes.Update(pacienteModel);
            labMedicineContext.SaveChanges();

            return Ok(new AtendimentoUpdateDTO(medicoModel, pacienteModel));
        }

        private ActionResult<AtendimentoUpdateDTO> NotFound(string v)
        {
            throw new NotImplementedException();
        }

        private ActionResult<AtendimentoUpdateDTO> Ok(AtendimentoUpdateDTO atendimentoUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}




    
