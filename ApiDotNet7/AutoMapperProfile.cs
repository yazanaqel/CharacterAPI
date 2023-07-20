using ApiDotNet7.Dtos.Character;
using ApiDotNet7.Models;
using AutoMapper;

namespace ApiDotNet7
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Character, GetCharacterResponseDto>();
			CreateMap<AddCharacterRequestDto, Character>();
		}
	}
}
