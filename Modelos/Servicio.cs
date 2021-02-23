using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParqueaderoApp
{
    class Servicio
    {
        [Key]
        [Required]
        [Column(TypeName = "INT(10)")]
        public int ServicioId { get; set; }

        [Required]
        [Column(TypeName = "CHAR(6)")]
        public string Matricula { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime FechaEntrada { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime FechaSalida { get; set; }

        [Column(TypeName = "BIT")]
        public bool Estado { get; set; } = true;

        [Column(TypeName = "INT(10)")]
        public int DuracionSercivio { get; set;}

        [Column(TypeName = "INT(10)")]
        public double ValorServicio { get; set; }
    }
}
