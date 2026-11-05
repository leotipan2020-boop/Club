using System.ComponentModel.DataAnnotations;

namespace ClubesApp.Models
{
    public class Jugador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(150, ErrorMessage = "El nombre puede tener máximo 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La posición es obligatoria")]
        [StringLength(50, ErrorMessage = "La posición puede tener máximo 50 caracteres")]
        [Display(Name = "Posición")]
        public string Posicion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El dorsal es obligatorio")]
        [Range(1, 99, ErrorMessage = "El dorsal debe estar entre 1 y 99")]
        [Display(Name = "Dorsal")]
        public int Dorsal { get; set; }
    }
}
