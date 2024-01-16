using BrewUp.Infrastructure.MongoDb.Readmodel;
using BrewUp.Sales.ReadModel.Dtos;
using BrewUp.Shared.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace BrewUp.Sales.Infrastructures;

public abstract class SalesQueries : Queries<SalesOrder> 
{
	protected readonly IMongoClient MongoClient;
	protected IMongoDatabase Database;

	protected SalesQueries(IMongoClient mongoClient): base(mongoClient)
	{		
		SetDatabaseName("Sales");
	}

	public async Task<SalesOrder> GetByIdAsync(string id, CancellationToken cancellationToken)
	{
		var collection = Database.GetCollection<SalesOrder>(typeof(SalesOrder).Name);
		var filter = Builders<SalesOrder>.Filter.Eq("_id", id);
		return (await collection.CountDocumentsAsync(filter) > 0 ? (await collection.FindAsync(filter)).First() : null)!;
	}

	public async Task<PagedResult<SalesOrder>> GetByFilterAsync(Expression<Func<SalesOrder, bool>>? query, int page, int pageSize, CancellationToken cancellationToken)
	{
		if (--page < 0)
			page = 0;

		var collection = Database.GetCollection<SalesOrder>(typeof(SalesOrder).Name);
		var queryable = query != null
			? collection.AsQueryable().Where(query)
			: collection.AsQueryable();

		var count = await queryable.CountAsync();
		var results = await queryable.Skip(page * pageSize).Take(pageSize).ToListAsync();

		return new PagedResult<SalesOrder>(results, page, pageSize, count);
	}
}