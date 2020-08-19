using Newtonsoft.Json.Converters;
using System;
using WIMS.Models;
using WIMS.Models.Contracts;

namespace Wims.Models.Converters
{
	public class BoardConverter : CustomCreationConverter<IBoard>
	{
		public override IBoard Create(Type objectType)
		{
			return new Board();
		}
	}
}
