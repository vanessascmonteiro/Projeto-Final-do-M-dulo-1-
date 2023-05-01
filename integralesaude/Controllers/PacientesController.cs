using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using integrale.Models;
using integralesaude.DTO;
using integralesaude.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using integralesaude.Enumerator;

namespace integralesaude.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly LabMedicineContext labMedicineContext;

        public PacientesController(LabMedicineContext labMedicineContext)
        {
           this.labMedicineContext = labMedicineContext;

        }
        [HttpPost]

        public ActionResult <PacienteUpdateDTO> Post ([FromBody] PacienteCreateDTO pacienteCreateDTO)
        {
            if(pacienteCreateDTO.CPF.Length != 11)
            {
                return BadRequest("CPF inválido"); 
            }

            var pacienteCadastrado = labMedicineContext.Pacientes.Where(x => x.Cpf == pacienteCreateDTO.CPF).FirstOrDefault();
            if(pacienteCadastrado !=null)
            {
                return Conflict("CPF já cadastrado");
            }
            else
            {
                return Ok("Paciente cadastrado com sucesso");
            }                        
        
                
            PacientesModel pacientesModel = new PacientesModel();

            pacientesModel.NomeCompleto = pacienteCreateDTO.NomeCompleto;
            pacientesModel.Cpf = pacienteCreateDTO.CPF;
            pacientesModel.ContatodeEmergencia = pacienteCreateDTO.ContatoEmergencia;
            pacientesModel.DataNascimento = pacienteCreateDTO.DataNascimento;
            pacientesModel.Convenio = pacienteCreateDTO.Convenio;
            pacientesModel.Genero = pacienteCreateDTO.Genero;
            pacientesModel.ListaAlergias = pacienteCreateDTO.ListaAlergias;
            pacientesModel.ListadeCuidadosEspecificos = pacienteCreateDTO.ListadeCuidadosEspecificos;
            pacientesModel.Telefone = pacienteCreateDTO.Telefone;
            pacientesModel.StatusAtendimento = Enumerator.StatusAtendimentoEnum.AguardandoAtendimento;
            pacientesModel.TotaldeAtendimentos ++;           


            labMedicineContext.Pacientes.Add(pacientesModel);
            labMedicineContext.SaveChanges();

            return StatusCode(201, new {pacientesModel.Id, pacientesModel.TotaldeAtendimentos});
                     
                  
        }
       
        [HttpPut]
        [Route ("{id}")]

        public ActionResult<PacienteUpdateDTO> Put ([FromBody] PacienteCreateDTO pacienteCreateDTO, int Id)
        {
            var pacienteCadastrado = labMedicineContext.Pacientes.FirstOrDefault(p => p.Id == Id);            
            
            if(pacienteCadastrado == null)
            {
                return NotFound ("Paciente não encontrado");
            } 
                       
            pacienteCadastrado.NomeCompleto = pacienteCreateDTO.NomeCompleto;
            pacienteCadastrado.Cpf = pacienteCreateDTO.CPF;
            pacienteCadastrado.ContatodeEmergencia = pacienteCreateDTO.ContatoEmergencia;
            pacienteCadastrado.DataNascimento= pacienteCreateDTO.DataNascimento;
            pacienteCadastrado.Convenio = pacienteCreateDTO.Convenio;
            pacienteCadastrado.Genero = pacienteCreateDTO.Genero;
            pacienteCadastrado.ListaAlergias = pacienteCreateDTO.ListaAlergias;
            pacienteCadastrado.ListadeCuidadosEspecificos = pacienteCreateDTO.ListadeCuidadosEspecificos;
            pacienteCadastrado.Telefone = pacienteCreateDTO.Telefone;
            pacienteCadastrado.StatusAtendimento = Enumerator.StatusAtendimentoEnum.AguardandoAtendimento;
            
            labMedicineContext.Attach(pacienteCadastrado);
            labMedicineContext.SaveChanges();

               return Ok(new PacienteUpdateDTO (pacienteCadastrado));
            }        
                 
     
    [HttpPut]
    [Route ("{id}/status")]
        public ActionResult<PacienteUpdateDTO>AtulizarStatus([FromRoute] int id, [FromBody] StatusAtendimentoDTO statusatendimentoDTO)
        {
            var pacienteStatus = labMedicineContext.Pacientes.FirstOrDefault(p => p.Id == id);
                if (pacienteStatus == null)
                {
                    return NotFound("Paciente não encontrado");
                }

                switch (statusatendimentoDTO.Status)
           {
            case "AguardandoAtendimento": 
            pacienteStatus.StatusAtendimento = Enumerator.StatusAtendimentoEnum.AguardandoAtendimento;
            break;

            case "Atendido": 
            pacienteStatus.StatusAtendimento = Enumerator.StatusAtendimentoEnum.Atendido;
            break;

            case "EmAtendimento": 
            pacienteStatus.StatusAtendimento = Enumerator.StatusAtendimentoEnum.EmAtendimento;
            break;

            case "NaoAtendido": 
            pacienteStatus.StatusAtendimento = Enumerator.StatusAtendimentoEnum.NaoAtendido;
            break;

            default: 
            return BadRequest("O Status deve ser: AguardandoAtendimento, Atendido, EmAtendimento ou NaoAtendido.");
           }

            labMedicineContext.Pacientes.Update(pacienteStatus);
            labMedicineContext.SaveChanges();

            return Ok(new PacienteUpdateDTO(pacienteStatus));
        }

        [HttpGet]
        public ActionResult<List<PacienteUpdateDTO>> ListaPacientes ([FromQuery] string status)
        {
            var listaPacientes = new List<PacientesModel>();

            switch (status)
           {
            case "AGUARDANDO_ATENDIMENTO": 
            listaPacientes = labMedicineContext.Pacientes.Where(p => p.StatusAtendimento == Enumerator.StatusAtendimentoEnum.AguardandoAtendimento).ToList();
            break;

            case "ATENDIDO": 
            listaPacientes = labMedicineContext.Pacientes.Where(p => p.StatusAtendimento == Enumerator.StatusAtendimentoEnum.Atendido).ToList();
            break;

            case "EM_ATENDIMENTO": 
            listaPacientes = labMedicineContext.Pacientes.Where(p => p.StatusAtendimento == Enumerator.StatusAtendimentoEnum.EmAtendimento).ToList();
            break;

            case "NAO_ATENDIDO": 
            listaPacientes = labMedicineContext.Pacientes.Where(p => p.StatusAtendimento == Enumerator.StatusAtendimentoEnum.NaoAtendido).ToList();
            break;

            default: 
            listaPacientes = labMedicineContext.Pacientes.ToList();
            break;
           }
        
            var listaDto = new List<PacienteUpdateDTO>();
            foreach (var pacienteModel in listaPacientes)
            {
                listaDto.Add(new PacienteUpdateDTO(pacienteModel));
            }
            return Ok(listaDto);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PacienteUpdateDTO> PesquisarPaciente([FromRoute] int id)
        {
            var pacienteModel = labMedicineContext.Pacientes.Where(w => w.Id == id).FirstOrDefault();

            if (pacienteModel == null)
            {
                return NotFound("Paciente não encontrado no sistema.");
            }
                PacienteUpdateDTO pacienteResponseDTO = new PacienteUpdateDTO(pacienteModel);
                return Ok(pacienteResponseDTO);
        }
                
                
    
    [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletarPacinete([FromRoute] int id)
        {
           var pacienteModel = labMedicineContext.Pacientes.FirstOrDefault(p => p.Id == id);
           if(pacienteModel == null) {
            return NotFound("Paciente não encontrado no sistema.");
           }
            labMedicineContext.Pacientes.Remove(pacienteModel);
            labMedicineContext.SaveChanges();
            
            return NoContent();
        }
    }
}










    







    


        









