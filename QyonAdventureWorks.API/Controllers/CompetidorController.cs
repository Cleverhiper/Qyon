using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QyonAdventureWorks.Domain.Entities;
using QyonAdventureWorks.Domain.Interfaces;
using QyonAdventureWorks.Domain.DTO;
using Microsoft.AspNetCore.Mvc;


namespace QyonAdventureWorks.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompetidorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompetidorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public async Task<IEnumerable<Competidor>> Get()
        {
            return await _unitOfWork.CompetidorRepo.GetAll();
        }

        [HttpGet("TempoMedioCompetidores")]
        public async Task<IEnumerable<DTOCompetidores>> GetTempoMedioCompetidores()
        {
            return await _unitOfWork.CompetidorRepo.GetTempoMedio();
        }


        [HttpGet("CompetidoresSemCorrida")]
        public async Task<IEnumerable<DTOCompetidores>> GetCompetidoresSemCorrida()
        {
            return await _unitOfWork.CompetidorRepo.GetSemCorrida();
        }

        [HttpGet("{id}")]
        public async Task<Competidor> Get(int id)
        {
            var result = await _unitOfWork.CompetidorRepo.Get(id);

            return await _unitOfWork.CompetidorRepo.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Competidor competidor)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            string mensagemValidacao = competidor.Validar();

            if (!String.IsNullOrEmpty(mensagemValidacao))
                return BadRequest(mensagemValidacao);

            await _unitOfWork.CompetidorRepo.Add(competidor);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("Get", new { id = competidor.CompetidorId });
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Competidor competidor)
        {
            var result = await _unitOfWork.CompetidorRepo.Get(id);

            if (result == null)
                BadRequest();

            if (result.CompetidorId != competidor.CompetidorId)
                return BadRequest();
            
            string mensagemValidacao = competidor.Validar();

            if (!String.IsNullOrEmpty(mensagemValidacao))
                return BadRequest(mensagemValidacao);

            _unitOfWork.CompetidorRepo.Update(competidor);
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var competidor = await _unitOfWork.CompetidorRepo.Get(id);

            if (competidor == null)
                return BadRequest();

            _unitOfWork.CompetidorRepo.Delete(competidor);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
