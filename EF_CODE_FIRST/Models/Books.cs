using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EF_CODE_FIRST.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30), Required(ErrorMessage = "Este titulo es requerido.")]
        public string Title { get; set; }

        [MaxLength(50), Required(ErrorMessage = "El nombre del autor es requerido")]
        public string Author { get; set; }

        public virtual ICollection<Reviews> Reviews { get; set; }

    }
}