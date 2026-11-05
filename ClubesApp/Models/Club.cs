using System.ComponentModel.DataAnnotations;


namespace ClubesApp.Models
{
    public class Club
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del club es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del club no puede tener más de 100 caracteres.")]
        [Display(Name = "Nombre del Club")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "La descripción del club no puede tener más de 100 caracteres."
            )]
        [Display(Name = "Cuidad")]
        public string? Ciudad { get; set; }

        public ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
    }
}
