using System.ComponentModel.DataAnnotations;

namespace Azienda.Shared
{
    public class Dipartimento
    {
        public int DipartimentoId { get; set; }
        [Required][MaxLength(100)] public string Nome { get; set; } = string.Empty;
        [MaxLength(255)] public string Localita { get; set; }
        [MaxLength(2)] public string Provincia { get; set; }
    }
}
