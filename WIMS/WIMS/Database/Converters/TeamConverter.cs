using Newtonsoft.Json.Converters;
using System;
using WIMS.Models;
using WIMS.Models.Contracts;

namespace Wims.Models.Converters
{
	public class TeamConverter : CustomCreationConverter<ITeam>
	{
		public override ITeam Create(Type objectType)
		{
			return new Team();
		}
	}
}