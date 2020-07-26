using System.ComponentModel.DataAnnotations;

namespace PruebaApi.Models
{
    public class Departamento
    {
          [Key]
          public int ID_Persona { get; set;}
          public string Nombre { get; set; }
      
    }
}