using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Domain.Entities;
using QyonAdventureWorks.Domain.Interfaces;
using QyonAdventureWorks.Infra.Context;

namespace QyonAdventureWorks.Infra.Repositories
{
    public class PistaCorridaRepository : GenericRepository<PistaCorrida>, IPistaCorridaRepository
    {
        public PistaCorridaRepository(QylonDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PistaCorrida>> GetPistaComCorrida()
        {
            List<PistaCorrida> pistasComCorridas = new List<PistaCorrida>();

            var listaPistas = await _context.PistaCorrida.ToListAsync();

            foreach (var pista in listaPistas)
            {
                var pistaCorrida = await _context.HistoricoCorrida.Where(x => x.PistaCorridaId == pista.PistaCorridaId).ToListAsync();

                if (pistaCorrida.Count > 0)
                    pistasComCorridas.Add(pista);
            }

            return pistasComCorridas;
        }
    }
}
