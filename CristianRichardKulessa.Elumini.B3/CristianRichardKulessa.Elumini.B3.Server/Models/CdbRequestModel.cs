using System.ComponentModel.DataAnnotations;

namespace CristianRichardKulessa.Elumini.B3.Server.Models
{
    public class CdbRequestModel
    {
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Valor deve ser maior que zero.")]
        public double Valor { get; set; }
        [Range(1, 60, ErrorMessage = "O campo Prazo deve ser entre 1 e 60.")]
        public int Prazo { get; set; }
    }
}