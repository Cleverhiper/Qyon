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
    public class PistaCorridaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PistaCorridaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public async Task<IEnumerable<PistaCorrida>> Get()
        {
            return await _unitOfWork.PistaCorridaRepo.GetAll();
        }

        //public async Task<IEnumerable<PistaCorrida>> GetPistasComCorrida()
        //{
        //    return await _unitOfWork.PistaCorridaRepo.GetPistaComCorrida();
        //}

        [HttpGet("{id}")]
        public async Task<PistaCorrida> Get(int id)
        {
            return await _unitOfWork.PistaCorridaRepo.Get(id);
        }

        [HttpGet ("PistaComCorrida")]
        public async Task<IEnumerable<PistaCorrida>> GetPistasComCorrida()
        {
            return await _unitOfWork.PistaCorridaRepo.GetPistaComCorrida();
        }

        //[HttpGet("genero")]
        //public async Task<IEnumerable<Livro>> GetByGenero([FromQuery] string genero)
        //{
        //    return await _unitOfWork.LivrosRepo.GetLivrosPorGenero(genero);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PistaCorrida pistaCorrida)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _unitOfWork.PistaCorridaRepo.Add(pistaCorrida);
            _unitOfWork.Commit();

            //return new CreatedAtRouteResult("Get", new { id = pistaCorrida.PistaCorridaId }, pistaCorrida);
            return new CreatedAtRouteResult("Get", new { id = pistaCorrida.PistaCorridaId });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PistaCorrida pistaCorrida)
        {
            var result = await _unitOfWork.PistaCorridaRepo.Get(id);

            if (result == null)
                BadRequest();

            if (result.PistaCorridaId != pistaCorrida.PistaCorridaId)
                return BadRequest();

            _unitOfWork.PistaCorridaRepo.Update(pistaCorrida);
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pistaCorrida = await _unitOfWork.PistaCorridaRepo.Get(id);

            if (pistaCorrida == null)
                return BadRequest();

            _unitOfWork.PistaCorridaRepo.Delete(pistaCorrida);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
