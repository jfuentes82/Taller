using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cascada_Drop.Models
{
    public class Producto
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        public virtual SubCategoria SubCategoria { get; set; }

        [Display(Name = "Sub Categoria")]
        public int SubCategoriaID { get; set; }
    }
}