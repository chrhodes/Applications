using System.Collections.Generic;
using System.Linq;

using PrismApp1.Application.Interfaces;

namespace PrismApp1.Application.Cat.Queries.GetCatList
{
    public class GetCatsListQuery : IGetCatsListQuery
    {
        private readonly IDatabaseService _database;

        public GetCatsListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<CatModel> Execute()
        //public List<Customer> Execute()
        {
            //using (var context = new CustomPoolAndSpaDbContext())
            //{
            //    return context.CustomerSet.AsNoTracking()
            //        .OrderBy(c => c.Name)
            //        .ToList();
            //}

            //var customers = _database.Customers.ToList();
            //return customers;

            var items = _database.Cats
                .Select(p => new CatModel()
                {
                    Id = p.Id,
                    //Name = p.FirstName
                });

            return items.ToList();
        }
    }
}
