using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EJERCICIO13JBSM.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombres { get; set; }
        [MaxLength(50)]
        public String apellidos { get; set; }
        [MaxLength(50)]
        public int edad { get; set; }
        public String correo { get; set; }
        [MaxLength(50)]
        public String direccion { get; set; }
    }
}
