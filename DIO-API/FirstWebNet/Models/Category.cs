using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstWebNet.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o campo de descrição")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }

    }
}