using System.Text.Json.Serialization;

namespace ApiDotNet7.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum RpgClass
	{
		None = 0,
		Knight = 1,
		Mage = 2,
		Cleric = 3
	}
}
