using ApiDotNet7.Dtos.Character;
using ApiDotNet7.Models;

namespace ApiDotNet7.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);
		Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto character);
		Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updateCharacter);
		Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id);
	}
}
