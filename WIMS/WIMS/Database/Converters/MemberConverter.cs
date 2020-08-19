using Newtonsoft.Json.Converters;
using System;
using WIMS.Models;
using WIMS.Models.Contracts;

namespace Wims.Models.Converters
{
	public class MemberConverter : CustomCreationConverter<IMember>
	{
		public override IMember Create(Type objectType)
		{
			return new Member();
		}
	}
}
