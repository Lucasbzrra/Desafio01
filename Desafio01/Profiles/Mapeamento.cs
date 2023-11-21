using AutoMapper;
using Desafio01.Data.Dtos;
using Desafio01.Models;

namespace Desafio01.Profiles;

public class Mapeamento:Profile
{
	public Mapeamento()
	{
		CreateMap<CreateCartaoDto, CartaoCredito>();
		CreateMap<UpdateCartaoDto, CartaoCredito>();
		CreateMap<CartaoCredito, ReadCartaoDto>();
	}
}
