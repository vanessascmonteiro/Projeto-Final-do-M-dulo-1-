using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.DTO;
using integralesaude.Models;
using Microsoft.AspNetCore.Mvc;

namespace integralesaude.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly LabMedicineContext labMedicineContext;

        public MedicosController(LabMedicineContext labMedicineContext)
        {
           this.labMedicineContext = labMedicineContext;

        }

        [HttpPost]
        [Route("/CadastroMedico")]
        public ActionResult <MedicoCreateDTO> Post ([FromBody] MedicoCreateDTO medicoCreateDTO)
        {
            if(medicoCreateDTO.CPF.Length != 11)
            {
                return BadRequest("CPF inválido"); 
            }

            var medico = labMedicineContext.Medicos.Where(x => x.Cpf == medicoCreateDTO.CPF).FirstOrDefault();
            if(medico !=null)
            {
                return Conflict("CPF já cadastrado");
            }
            MedicosModel medicoCadastrado = new MedicosModel();        
               
            medicoCadastrado.NomeCompleto = medicoCreateDTO.NomeCompleto;
            medicoCadastrado.Cpf = medicoCreateDTO.CPF;
            medicoCadastrado.CRM = medicoCreateDTO.CRM;
            medicoCadastrado.Telefone = medicoCreateDTO.Telefone;
            medicoCadastrado.InstituicaodeEnsino = medicoCreateDTO.InstituicaodeEnsino;
            medicoCadastrado.EspecializacaoClinica = medicoCreateDTO.EspecializacaoClinica;
            medicoCadastrado.EstadonoSistema = medicoCreateDTO.EstadonoSistema;
            medicoCadastrado.TotaldeAtendimentos = medicoCreateDTO.TotaldeAtendimentos;           


            labMedicineContext.Medicos.Add(medicoCadastrado);
            labMedicineContext.SaveChanges();

            return Created ($"/{medicoCadastrado.Id}", new MedicoUpdateDTO(medicoCadastrado));                          
               
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<MedicoUpdateDTO> AtualizarMedico([FromRoute] int id, [FromBody]MedicoCreateDTO medicoCreateDTO)
        {
            var medicoModel = labMedicineContext.Medicos.FirstOrDefault(m => m.Id == id);
           if(medicoModel == null) {
            return NotFound("Medico não encontrado no sistema.");
           }
            medicoModel.NomeCompleto = medicoCreateDTO.NomeCompleto;
            medicoModel.Genero = medicoCreateDTO.Genero;
            medicoModel.TotaldeAtendimentos = medicoCreateDTO.TotaldeAtendimentos;
            medicoModel.DataNascimento = medicoCreateDTO.DataNascimento;
            medicoModel.Cpf = medicoCreateDTO.CPF;
            medicoModel.CRM = medicoCreateDTO.CRM;
            medicoModel.Telefone = medicoCreateDTO.Telefone;
            medicoModel.InstituicaodeEnsino = medicoCreateDTO.InstituicaodeEnsino;
            medicoModel.EspecializacaoClinica = medicoCreateDTO.EspecializacaoClinica;
            medicoModel.EstadonoSistema = medicoCreateDTO.EstadonoSistema;
            medicoModel.TotaldeAtendimentos = medicoCreateDTO.TotaldeAtendimentos;
            labMedicineContext.Medicos.Update(medicoModel);
            labMedicineContext.SaveChanges();

            return Ok(new MedicoUpdateDTO(medicoModel));
        }

        [HttpPut]
        [Route("{id}/status")]
        public ActionResult<MedicoUpdateDTO> AtualizarStatusMedico([FromRoute] int id,[FromBody]StatusAtendimentoDTO statusAtendimentoDTO)
        {
           var medicoModel = labMedicineContext.Medicos.FirstOrDefault(p => p.Id == id);
           if(medicoModel == null) {
            return NotFound("Médico não encontrado no sistema."); 
           }

           switch (statusAtendimentoDTO.Status)
           {
            case "Ativo": 
            medicoModel.EstadonoSistema = Enumerator.EstadonoSistemaEnum.Ativo;
            break;

            case "Inativo": 
            medicoModel.EstadonoSistema = Enumerator.EstadonoSistemaEnum.Inativo;
            break;

            default: 
            return BadRequest("O Status deve ser informado como Ativo ou Inativo.");
           }

            labMedicineContext.Medicos.Update(medicoModel);
            labMedicineContext.SaveChanges();

            return Ok(new MedicoUpdateDTO(medicoModel));
        }
        
        [HttpGet]
        public ActionResult<List<MedicoUpdateDTO>> ListarMedicos([FromQuery] string status)
        {
            var listaMedicos = new List<MedicosModel>();
            switch (status)
           {
            case "ATIVO": 
            listaMedicos = labMedicineContext.Medicos.Where(m => m.EstadonoSistema == Enumerator.EstadonoSistemaEnum.Ativo).ToList();
            break;

            case "INATIVO": 
            listaMedicos = labMedicineContext.Medicos.Where(m => m.EstadonoSistema == Enumerator.EstadonoSistemaEnum.Inativo).ToList();
            break;

            default: 
            listaMedicos = labMedicineContext.Medicos.ToList();
            break;
           }
            
            var listaDto = new List<MedicoUpdateDTO>();
            foreach (var medicoModel in listaMedicos)
            {
                listaDto.Add(new MedicoUpdateDTO(medicoModel));
            }
            return Ok(listaDto);
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<MedicoUpdateDTO> PesquisarMedico([FromRoute] int id)
        {
            var medicoModel = labMedicineContext.Medicos.FirstOrDefault(m => m.Id == id);
           if(medicoModel == null) {
            return NotFound("Médico não encontrado no sistema.");
           }
            return Ok(new MedicoUpdateDTO(medicoModel));
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletarMedico([FromRoute] int id)
        {
           var medicoModel = labMedicineContext.Medicos.FirstOrDefault(m => m.Id == id);
           if(medicoModel == null) {
            return NotFound("Médico não encontrado no sistema.");
           }
            labMedicineContext.Medicos.Remove(medicoModel);
            labMedicineContext.SaveChanges();
            
            return NoContent();
        }
    }
}