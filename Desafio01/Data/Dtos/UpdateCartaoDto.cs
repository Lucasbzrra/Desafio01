namespace Desafio01.Data.Dtos;

public class UpdateCartaoDto
{
    public string UserDocument { get; set; }
    public string CartaoToken { get; set; }
    public double Value { get; set; }
}
