using System.ComponentModel.DataAnnotations;

namespace Desafio01.Models;

public class CartaoCredito
{
    public string Id { get; set; }

    [Required(ErrorMessage ="Obrigatorio")]
    [MinLength(6)]
    public string UserDocument { get; set; }
    [Required(ErrorMessage = "Obrigatorio")]
    [MinLength(6)]
    public string CartaoToken { get; set; }
    [Range(0,100000)]
    public double Value { get; set; }
}
