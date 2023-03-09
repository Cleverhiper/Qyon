using System;
using System.Collections.Generic;
using System.Text;

namespace QyonAdventureWorks.Domain.DTO
{
    public class DTOCompetidores
    {
        public int CompetidorId { get; set; }        
        public string Nome { get; set; }

        public int TotalCorridas { get; set; }
        public decimal TotalTempo { get; set; }
        public decimal TempoMedio { get; set; }
    }
}
