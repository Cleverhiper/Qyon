using System;
using System.Collections.Generic;
using System.Text;
using QyonAdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace QyonAdventureWorks.Infra.Context
{
    public class QylonDbContext : DbContext
    {
        public QylonDbContext(DbContextOptions<QylonDbContext> options) : base(options)
        {

        }
        
        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<PistaCorrida> PistaCorrida { get; set; }
        public DbSet<HistoricoCorrida> HistoricoCorrida { get; set; }
    }
}
