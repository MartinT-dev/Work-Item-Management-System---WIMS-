using Newtonsoft.Json.Converters;
using System;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems;
using WIMS.Models.WorkItems.Contracts;

namespace Wims.Models.Converters
{
	public class FeedbackConverter : CustomCreationConverter<IFeedback>
	{
		public override IFeedback Create(Type objectType)
		{
			return new Feedback();
		}
	}
}
