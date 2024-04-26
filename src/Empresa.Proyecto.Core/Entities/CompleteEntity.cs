using System.ComponentModel.DataAnnotations;

namespace Empresa.Proyecto.Core.Entities
{
    public class CompleteEntity : BaseEntity
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El Nombre es requerido.")]

		public string? Name { get; set; }

        [Display(Name = "SimpleEntityId")]
        [Required(ErrorMessage = "El SimpleEntityId es requerido.")]
        public int? SimpleEntityId { get; set; }

        public virtual SimpleEntity SimpleEntity { get; set; } = null!;
    }
}