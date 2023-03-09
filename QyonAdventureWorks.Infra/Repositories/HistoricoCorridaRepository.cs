using System;
using System.Collections.Generic;
using System.Text;
using QyonAdventureWorks.Domain.Entities;
using QyonAdventureWorks.Domain.Interfaces;
using QyonAdventureWorks.Infra.Context;


namespace QyonAdventureWorks.Infra.Repositories
{
    public class HistoricoCorridaRepository :GenericRepository<HistoricoCorrida>, IHistoricoCorridaRepository
    {
        public HistoricoCorridaRepository(QylonDbContext context) : base(context)
        {

        }
    }
}
