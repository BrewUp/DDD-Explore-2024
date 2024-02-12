using Muflone.Core;

namespace BrewUp.Shared.CustomTypes;

public sealed class BeerId : DomainId
{
	public BeerId(Guid value) : base(value)
	{
	}
}