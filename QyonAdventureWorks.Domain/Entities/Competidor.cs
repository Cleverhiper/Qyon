using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QyonAdventureWorks.Domain.Entities
{
    public class Competidor
    {
        public int CompetidorId { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Nome { get; set; }


        [Column(TypeName = "char(1)")]
        public string Sexo { get; set; }

        public decimal TemperaturaMediaCorpo { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }

        public string Validar()
        {
            var mensagemRetorno = "";

            if (Altura < 0)
                mensagemRetorno = "A Altura deve ser um valor positivo!";

            if (Peso < 0)
                mensagemRetorno = "O Peso deve ser um valor positivo!";

            if (!(Sexo == "M" || Sexo == "F" || Sexo == "O"))
                mensagemRetorno = "Sexo deve ser (M, F ou O)";

            if (TemperaturaMediaCorpo < 36 || TemperaturaMediaCorpo > 38)
                mensagemRetorno = "Temperatura Média do Corpo fora do permitido (Entre 36 e 38 graus)";
            
            return mensagemRetorno;
        }

    }
}
