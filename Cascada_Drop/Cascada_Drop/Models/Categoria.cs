using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cascada_Drop.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; }



    }
}