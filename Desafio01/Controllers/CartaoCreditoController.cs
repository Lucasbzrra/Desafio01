using AutoMapper;
using Desafio01.Data;
using Desafio01.Data.Dtos;
using Desafio01.Models;
using Desafio01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio01.Controllers;

[ApiController]
[Route("/Controller")]
public class CartaoCreditoController:ControllerBase
{
	private IMapper _mapper;
	private CartaoDbContext _cartaoDb;
	private CriptografiaDados criptografia;
	public CartaoCreditoController(IMapper mapper, CartaoDbContext cartaoDb, CriptografiaDados dados)
	{
		_mapper= mapper;
		_cartaoDb= cartaoDb;
		criptografia= dados;
	}
	[HttpPost("/Cadastro")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult CadastroCartao([FromBody] CreateCartaoDto createCartaoDto)
	{
		bool Localizou= _cartaoDb.CartaoCredito.Any(x=>x.Id.Equals(createCartaoDto.Id));
		if(!Localizou)
		{
            List<string> DateCrypetd = new List<string>();
			CartaoCredito cartaoCredito = _mapper.Map<CartaoCredito>(createCartaoDto);
			DateCrypetd= criptografia.Codificando(cartaoCredito).ToList();
			cartaoCredito.CartaoToken = DateCrypetd[1];
			cartaoCredito.UserDocument = DateCrypetd[0];
			_cartaoDb.CartaoCredito.Add(cartaoCredito);
			Console.WriteLine(cartaoCredito);
			_cartaoDb.SaveChanges();
			return Ok();
        }
		return NoContent();

        

    }
	[HttpGet("/Visualizar")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public IEnumerable<ReadCartaoDto> Get()
	{
        return _mapper.Map<List<ReadCartaoDto>>(_cartaoDb.CartaoCredito);
	}



	[HttpDelete("/Deletar-{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public IActionResult DeletarUser(string id)
	{
		var Localiza=_cartaoDb.CartaoCredito.FirstOrDefault(x => x.Id.Equals(id));
		if (Localiza is null)
		{
			return BadRequest("Usuairo não encontrado");
		}
		_cartaoDb.CartaoCredito.Remove(Localiza);
		_cartaoDb.SaveChanges();
		return NoContent();
	}

    [HttpPut("/AlterarDados-{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult AlterarDados(string id, [FromBody] UpdateCartaoDto updateCartaoDto)
    {
        var EncontrouID = _cartaoDb.CartaoCredito.FirstOrDefault(x => x.Id.Equals(id));
        if (EncontrouID is null)
        {
            return NotFound("Id não encontrado no sistema");
        }
        CartaoCredito cartao = new CartaoCredito
        {
            CartaoToken = updateCartaoDto.CartaoToken,
            UserDocument = updateCartaoDto.UserDocument,
        };

        List<string> codificado = new List<string>();
        codificado = criptografia.Codificando(cartao).ToList();
        updateCartaoDto.UserDocument = codificado[1];
        updateCartaoDto.CartaoToken = codificado[1];

        _mapper.Map(updateCartaoDto, EncontrouID);
        _cartaoDb.SaveChanges();
        return Accepted(updateCartaoDto);

    }

}
