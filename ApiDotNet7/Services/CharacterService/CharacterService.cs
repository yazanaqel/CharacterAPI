using ApiDotNet7.Data;
using ApiDotNet7.Dtos.Character;
using ApiDotNet7.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet7.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		private readonly IMapper mapper;
		private readonly ApplicationDbContext dbContext;

		public CharacterService(IMapper mapper, ApplicationDbContext dbContext)
		{
			this.mapper = mapper;
			this.dbContext = dbContext;
		}
		public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto character)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
			var newCharacter = mapper.Map<Character>(character);
			dbContext.Characters.Add(newCharacter);
			await dbContext.SaveChangesAsync();
			var characters = await dbContext.Characters.ToListAsync();
			serviceResponse.Data = characters.Select(x => mapper.Map<GetCharacterResponseDto>(x)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
			var characters = await dbContext.Characters.ToListAsync();
			serviceResponse.Data = characters.Select(x => mapper.Map<GetCharacterResponseDto>(x)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
		{
			var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
			var character =await dbContext.Characters.FirstOrDefaultAsync(x => x.Id == id);
			serviceResponse.Data = mapper.Map<GetCharacterResponseDto>(character);
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updateCharacter)
		{
			var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

			try
			{
				var character = await dbContext.Characters.FirstOrDefaultAsync(x => x.Id == updateCharacter.Id);

				if(character is null)
				{
					throw new Exception($"character with id '{updateCharacter.Id}' not found");
				}

				character.Name = updateCharacter.Name;
				character.HitPoints = updateCharacter.HitPoints;
				character.Strength = updateCharacter.Strength;
				character.Defence = updateCharacter.Defence;
				character.Intelligance = updateCharacter.Intelligance;
				character.Class = updateCharacter.Class;

				dbContext.Characters.Update(character);
				await dbContext.SaveChangesAsync();
				serviceResponse.Data = mapper.Map<GetCharacterResponseDto>(character);
			}
			catch(Exception ex)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = ex.Message;
			}
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();

			try
			{
				var character = await dbContext.Characters.FirstOrDefaultAsync(x => x.Id == id);

				if (character is null)
				{
					throw new Exception($"character with id '{id}' not found");
				}

				dbContext.Characters.Remove(character);

				await dbContext.SaveChangesAsync();
				serviceResponse.Data =await dbContext.Characters.Select(x => mapper.Map<GetCharacterResponseDto>(x)).ToListAsync();
			}
			catch (Exception ex)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = ex.Message;
			}
			return serviceResponse;
		}

	}
}
