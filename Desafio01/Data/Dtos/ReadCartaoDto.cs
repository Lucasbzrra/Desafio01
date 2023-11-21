namespace Desafio01.Data.Dtos;

public class ReadCartaoDto
{
    public string UserDocument { get; set; }
    public string CartaoToken { get; set; }
    public double Value { get; set; }
    public DateTime DataConsulta { get; }= DateTime.Now;
}
