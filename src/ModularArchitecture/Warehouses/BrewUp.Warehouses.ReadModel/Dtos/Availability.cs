using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.Entities;

namespace BrewUp.Warehouses.ReadModel.Dtos;

public class Availability : EntityBase
{
	public string BeerId { get; private set; } = string.Empty;
	public string BeerName { get; private set; } = string.Empty;

	public Quantity Quantity { get; private set; } = new(0, string.Empty);

	protected Availability()
	{
	}

	public static Availability Create(BeerId beerId, BeerName beerName, Quantity quantity)
	{
		return new Availability(beerId.Value.ToString(), beerName.Value, quantity);
	}

	private Availability(string beerId, string beerName, Quantity quantity)
	{
		Id = beerId;

		BeerId = beerId;
		BeerName = beerName;
		Quantity = quantity;
	}
}