using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QyonAdventureWorks.Domain.Entities
{
    public class PistaCorrida
    {
        public int PistaCorridaId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Descricao { get; set; }

       
    }
}
