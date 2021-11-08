

using System.ComponentModel.DataAnnotations;

namespace FirstWebNet.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o campo de descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Seu produto esta sem preço")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Seu produto esta sem quantidade")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Seu produto não tem categoria")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}