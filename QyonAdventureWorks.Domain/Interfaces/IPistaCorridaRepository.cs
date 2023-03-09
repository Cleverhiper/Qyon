using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QyonAdventureWorks.Domain.Entities;

namespace QyonAdventureWorks.Domain.Interfaces
{
    public interface IPistaCorridaRepository : IGenericRepository<PistaCorrida>
    {        
        Task<IEnumerable<PistaCorrida>> GetPistaComCorrida();
    }
}
