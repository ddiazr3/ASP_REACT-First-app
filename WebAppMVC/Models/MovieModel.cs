using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class MovieModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(30)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Genero es requerido")]
        public string Genero { get; set; }

    }
}
