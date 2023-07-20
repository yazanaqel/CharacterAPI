using ApiDotNet7.Dtos.Character;
using ApiDotNet7.Models;
using ApiDotNet7.Services.CharacterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet7.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CharacterController : ControllerBase
	{
		public CharacterController(ICharacterService characterService)
		{
			this.characterService = characterService;
		}

		private readonly ICharacterService characterService;

		[HttpGet("GetAll")]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> Get()
			=> Ok(await characterService.GetAllCharacters());

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetSingle(int id)
		=> Ok(await characterService.GetCharacterById(id));

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> Add(AddCharacterRequestDto character)
		=> Ok(await characterService.AddCharacter(character));

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> Update(UpdateCharacterRequestDto character)
		{
			var response = await characterService.UpdateCharacter(character);

			if (response.Data is null) return NotFound(response);

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> Delete(int id)
		{
			var response = await characterService.DeleteCharacter(id);

			if (response.Data is null) return NotFound(response);

			return Ok(response);
		}

	}
}
