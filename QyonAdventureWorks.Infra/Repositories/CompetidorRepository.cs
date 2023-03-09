using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QyonAdventureWorks.Domain.Entities;
using QyonAdventureWorks.Domain.Interfaces;
using QyonAdventureWorks.Infra.Context;
using QyonAdventureWorks.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QyonAdventureWorks.Infra.Repositories
{
    public class CompetidorRepository : GenericRepository<Competidor>, ICompetidorRepository
    {
        public CompetidorRepository(QylonDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<DTOCompetidores>> GetTempoMedio()
        {
            List<DTOCompetidores> competidoresComTempo = new List<DTOCompetidores>();

            var listaCompetidores = await _context.Competidores.ToListAsync();

            foreach (var competidor in listaCompetidores)
            {
                var corridasDoCompetidor = await _context.HistoricoCorrida.Where(x => x.CompetidorId == competidor.CompetidorId).ToListAsync();
                
                int numeroCorridas = 0;
                decimal tempoTotal = 0M;
                decimal tempoMedio = 0M;

                
                foreach (var corridas in corridasDoCompetidor)
                {
                    numeroCorridas++;
                    tempoTotal += corridas.TempoGasto;
                }

                if (numeroCorridas > 0 && tempoTotal > 0)
                {
                    tempoMedio = tempoTotal / numeroCorridas;
                    competidoresComTempo.Add(new DTOCompetidores
                        {
                            CompetidorId = competidor.CompetidorId,
                            Nome = competidor.Nome,
                            TotalCorridas = numeroCorridas,
                            TotalTempo = tempoTotal,
                            TempoMedio = tempoMedio
                        }
                    );

                }                                    
            }

            return competidoresComTempo;
        }

        public async Task<IEnumerable<DTOCompetidores>> GetSemCorrida()
        {
            List<DTOCompetidores> competidoresSemCorrida = new List<DTOCompetidores>();

            var listaCompetidores = await _context.Competidores.ToListAsync();

            foreach (var competidor in listaCompetidores)
            {
                var corridasDoCompetidor = await _context.HistoricoCorrida.Where(x => x.CompetidorId == competidor.CompetidorId).ToListAsync();
               
                if (corridasDoCompetidor.Count == 0)
                {
                    competidoresSemCorrida.Add(new DTOCompetidores
                    {
                        CompetidorId = competidor.CompetidorId,
                        Nome = competidor.Nome,
                        TotalCorridas = 0,
                        TotalTempo = 0,
                        TempoMedio = 0
                    });
                }               
            }

            return competidoresSemCorrida;
        }
    }
}
