using System;

namespace Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto
        {
            get
            {
                return ($"{Nombre} {Apellido}");
            }
        }
        public DateTime FechaNacimiento { get; set; }
    }
}