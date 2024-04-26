using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Proyecto.Core.Entities
{
    /// <summary>
    /// Clase base para entidades de EF
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id de la entidad, PK
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// Fecha creacion de la entidad
        /// </summary>
        [Display(Name = "Fecha creación")]
        [Required(ErrorMessage = "La Fecha creación es requerida.")]
        public DateTime? Created { get; set; }
        /// <summary>
        /// Ultima modificacion de la entidad
        /// </summary>
        [Display(Name = "Ultima modificacion")]
        [Required(ErrorMessage = "La Ultima modificacion es requerida.")]
        public DateTime? Modified { get; set; }
    }

}