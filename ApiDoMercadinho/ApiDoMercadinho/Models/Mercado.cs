using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiDoMercadinho.Models
{
    public class Mercado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço do produto deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque do produto é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque do produto deve ser maior ou igual a zero.")]
        public int Estoque { get; set; }
    }
}
