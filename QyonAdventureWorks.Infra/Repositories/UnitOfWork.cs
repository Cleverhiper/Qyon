using QyonAdventureWorks.Domain.Interfaces;
using QyonAdventureWorks.Infra.Context;
using System;

namespace QyonAdventureWorks.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QylonDbContext _context;        
        public ICompetidorRepository CompetidorRepo { get; }

        public IPistaCorridaRepository PistaCorridaRepo { get; }

        public IHistoricoCorridaRepository HistoricoCorridaRepo { get; }

        public UnitOfWork(QylonDbContext context, ICompetidorRepository competidores, IPistaCorridaRepository pistaCorrida,  IHistoricoCorridaRepository historicoCorrida)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));            
            CompetidorRepo = competidores ?? throw new ArgumentException(nameof(competidores));
            PistaCorridaRepo = pistaCorrida ?? throw new ArgumentNullException(nameof(pistaCorrida));
            HistoricoCorridaRepo = historicoCorrida ?? throw new ArgumentNullException(nameof(historicoCorrida));
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
