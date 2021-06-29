using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordManager2.Models
{
    public class WordModel
    {
        public int WordID { get; set; }
        [DisplayName("Słowo")]
        [Required(ErrorMessage = "To pole nie może być puste.")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
