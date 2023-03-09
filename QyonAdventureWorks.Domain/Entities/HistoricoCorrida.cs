using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QyonAdventureWorks.Domain.Entities
{
    public class HistoricoCorrida
    {
        public int HistoricoCorridaId { get; set; }
        public int CompetidorId { get; set; }
        public int PistaCorridaId { get; set; }
        public DateTime DataCorrida { get; set; }
        public decimal TempoGasto { get; set; }

        //public Collection<Competidor> Competidores { get;  }

        //public Collection<PistaCorrida> PistaCorridas { get; }


        public string Validar()
        {
            string mensagemRetorno = "";

            if (DataCorrida > DateTime.Now)
                mensagemRetorno = "Só permitido lançamento de Data de Corrida menores que a Data Atual!";

            return mensagemRetorno;
        }
    }
}
