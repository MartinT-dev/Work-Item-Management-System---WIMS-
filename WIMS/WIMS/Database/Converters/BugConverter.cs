using Newtonsoft.Json.Converters;
using System;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems;
using WIMS.Models.WorkItems.Contracts;

namespace Wims.Models.Converters
{
	public class BugConverter : CustomCreationConverter<IBug>
	{
		public override IBug Create(Type objectType)
		{
			return new Bug();
		}
	}
}
