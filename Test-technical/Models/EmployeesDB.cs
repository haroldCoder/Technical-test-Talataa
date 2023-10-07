using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_technical.Models
{
    public class EmployeesDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        public int Documento { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(20)]
        public string Teléfono { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Dirección { get; set; }

        [Required]
        [MaxLength(1)]
        [RegularExpression("[MF]")]
        public string Género { get; set; }
    }
}
