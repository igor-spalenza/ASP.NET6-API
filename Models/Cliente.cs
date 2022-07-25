using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET6_API.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O campo Nome é de preenchimento obrigatório.")]
        public string Nome { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "O campo Email é de preenchimento obrigatório.")]
        public string Email { get; set; }
    }
}
