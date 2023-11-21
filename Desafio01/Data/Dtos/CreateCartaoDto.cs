using System.ComponentModel.DataAnnotations;

namespace Desafio01.Data.Dtos;

public class CreateCartaoDto
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserDocument { get; set; }
    public string CartaoToken { get; set; }

    public double Value { get; set; }
}
