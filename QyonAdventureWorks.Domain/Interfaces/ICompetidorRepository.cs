using System;
using System.Collections.Generic;
using System.Text;
using QyonAdventureWorks.Domain.Entities;
using QyonAdventureWorks.Domain.DTO;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Domain.Interfaces
{
    public interface ICompetidorRepository : IGenericRepository<Competidor>
    {
        Task<IEnumerable<DTOCompetidores>> GetTempoMedio();
        Task<IEnumerable<DTOCompetidores>> GetSemCorrida();
    }
}
