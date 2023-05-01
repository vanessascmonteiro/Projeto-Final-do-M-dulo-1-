using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using integralesaude.DTO;
using integralesaude.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace integralesaude.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnfermeirosController : ControllerBase
    {
        private readonly LabMedicineContext labMedicineContext;

        public EnfermeirosController(LabMedicineContext labMedicineContext)
        {
           this.labMedicineContext = labMedicineContext;

        }
        [HttpPost]
        public ActionResult<EnfermeiroUpdateDTO> CadastrarEnfermeiro([FromBody] EnfermeiroCreateDTO enfermeiroCreateDto)
        {
            var enfermeiro = labMedicineContext.Enfermeiros.FirstOrDefault(e => e.Cpf == enfermeiroCreateDto.CPF);
           if(enfermeiro != null) {
            return Conflict("Já existe um enfermeiro cadastrado no sistema com esse CPF.");
           }
            EnfermeirosModel enfermeiroModel = new EnfermeirosModel();

            enfermeiroModel.NomeCompleto = enfermeiroCreateDto.NomeCompleto;
            enfermeiroModel.Genero = enfermeiroCreateDto.Genero;
            enfermeiroModel.DataNascimento = enfermeiroCreateDto.DataNascimento;
            enfermeiroModel.Cpf = enfermeiroCreateDto.CPF;
            enfermeiroModel.Telefone = enfermeiroCreateDto.Telefone;
            enfermeiroModel.InstituicaodeEnsino = enfermeiroCreateDto.InstituicaodeEnsino;
            enfermeiroModel.COFEN = enfermeiroCreateDto.COFEN;
            labMedicineContext.Enfermeiros.Add(enfermeiroModel);
            labMedicineContext.SaveChanges();
            return Created($"/{enfermeiroModel.Id}", new EnfermeiroUpdateDTO (enfermeiroModel)); 
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<EnfermeiroUpdateDTO> AtualizarEnfermeiro([FromRoute] int id, [FromBody] EnfermeiroCreateDTO enfermeiroCreateDto)
        {
           var enfermeiroModel = labMedicineContext.Enfermeiros.FirstOrDefault(e => e.Id == id);
           if(enfermeiroModel == null) {
            return NotFound("Enfermeiro não encontrado no sistema.");
           }
            enfermeiroModel.NomeCompleto = enfermeiroCreateDto.NomeCompleto;
            enfermeiroModel.Genero = enfermeiroCreateDto.Genero;
            enfermeiroModel.DataNascimento = enfermeiroCreateDto.DataNascimento;
            enfermeiroModel.Cpf = enfermeiroCreateDto.CPF;
            enfermeiroModel.Telefone = enfermeiroCreateDto.Telefone;
            enfermeiroModel.InstituicaodeEnsino = enfermeiroCreateDto.InstituicaodeEnsino;
            enfermeiroModel.COFEN = enfermeiroCreateDto.COFEN;
            labMedicineContext.Enfermeiros.Update(enfermeiroModel);
            labMedicineContext.SaveChanges();

            return Ok(new EnfermeiroUpdateDTO(enfermeiroModel));
        }

        [HttpGet]
        public ActionResult<List<EnfermeiroUpdateDTO>> ListarEnfermeiros([FromBody] EnfermeiroCreateDTO enfermeiroCreateDto)
        {
            var listaEnfermeiros = labMedicineContext.Enfermeiros;
            var listaEnfermeiroCreateDto = new List<EnfermeiroUpdateDTO>();
            foreach (var enfermeiromodel in listaEnfermeiros)
            {
                listaEnfermeiroCreateDto.Add(new EnfermeiroUpdateDTO(enfermeiromodel));
            }
            return Ok(listaEnfermeiroCreateDto);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<EnfermeiroUpdateDTO> PesquisarEnfermeiro([FromRoute] int id)
        {
            var enfermeiroModel = labMedicineContext.Enfermeiros.FirstOrDefault(e => e.Id == id);
           if(enfermeiroModel == null) {
            return NotFound("Enfermeiro não encontrado no sistema.");
           }
            return Ok(new EnfermeiroUpdateDTO(enfermeiroModel));
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletarEnfermeiro([FromRoute] int id)
        {
            var enfermeiroModel = labMedicineContext.Enfermeiros.FirstOrDefault(e => e.Id == id);
           if(enfermeiroModel == null) {
            return NotFound("Enfermeiro não encontrado no sistema.");
           }
            labMedicineContext.Enfermeiros.Remove(enfermeiroModel);
            labMedicineContext.SaveChanges();
            
            return NoContent();
        }
    }
}