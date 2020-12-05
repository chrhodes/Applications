using System.Collections.Generic;

namespace PrismApp1.Application.Cat.Queries.GetCatList
{
    public interface IGetCatsListQuery
    {
        List<CatModel> Execute();
        //List<Customer> Execute();
    }
}
