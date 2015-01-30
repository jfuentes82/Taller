using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cascada_Drop.Models
{
    public class SubCategoria
    {
        [Key]
        public int SubCategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}