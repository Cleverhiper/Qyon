using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QyonAdventureWorks.Domain.Entities;
using QyonAdventureWorks.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace QyonAdventureWorks.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HistoricoCorridaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HistoricoCorridaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public async Task<IEnumerable<HistoricoCorrida>> Get()
        {
            return await _unitOfWork.HistoricoCorridaRepo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<HistoricoCorrida> Get(int id)
        {
            return await _unitOfWork.HistoricoCorridaRepo.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HistoricoCorrida historicoCorrida)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            string mensagemValidacao = historicoCorrida.Validar();

            if (!String.IsNullOrEmpty(mensagemValidacao))
                return BadRequest(mensagemValidacao);

            await _unitOfWork.HistoricoCorridaRepo.Add(historicoCorrida);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("Get", new { id = historicoCorrida.HistoricoCorridaId });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, int idPistaCorrida, [FromBody] HistoricoCorrida historicoCorrida)
        {
            var result = await _unitOfWork.HistoricoCorridaRepo.Get(id);

            if (result == null)
                BadRequest();

            if (result.HistoricoCorridaId != historicoCorrida.HistoricoCorridaId)
                return BadRequest();

            string mensagemValidacao = historicoCorrida.Validar();

            if (!String.IsNullOrEmpty(mensagemValidacao))
                return BadRequest(mensagemValidacao);

            _unitOfWork.HistoricoCorridaRepo.Update(historicoCorrida);
            _unitOfWork.Commit();

            return Ok();
        }
      
    }
}
