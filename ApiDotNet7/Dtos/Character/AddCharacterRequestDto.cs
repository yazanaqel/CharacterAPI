using ApiDotNet7.Models;

namespace ApiDotNet7.Dtos.Character
{
	public class AddCharacterRequestDto
	{
		public string Name { get; set; } = "Frodoo";
		public int HitPoints { get; set; } = 100;
		public int Strength { get; set; } = 10;
		public int Defence { get; set; } = 10;
		public int Intelligance { get; set; } = 10;
		public RpgClass Class { get; set; } = RpgClass.Mage;
	}
}
