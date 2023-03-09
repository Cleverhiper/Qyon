using System;

namespace QyonAdventureWorks.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {     
        ICompetidorRepository CompetidorRepo { get;  }
        IPistaCorridaRepository PistaCorridaRepo { get; }

        IHistoricoCorridaRepository HistoricoCorridaRepo { get; }
        int Commit();
    }
}
