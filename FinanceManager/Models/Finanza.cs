using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Models
{
    public class Finanza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El tipo de ovimiento  es obligatorio.")]
        public required string Tipo { get; set; }
        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "Coloca una categoria")]
        public required int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Coloca la fecha en que se realizo")]
        public required DateTime Fecha { get; set; }
        
    }
}
