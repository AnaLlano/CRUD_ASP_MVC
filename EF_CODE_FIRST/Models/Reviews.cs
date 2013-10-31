using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF_CODE_FIRST.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text), Required(ErrorMessage = "La critica es un campo requerido")]
        public string Review { get; set; }

        [MaxLength(35), Required(ErrorMessage = "El nombre es requerido.")]
        public string User { get; set; }


        public int BooksId { get; set; }

        [ForeignKey("BooksId")]
        public Books Books { get; set; }


    }
}