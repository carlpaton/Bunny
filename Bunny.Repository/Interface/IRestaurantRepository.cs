using Bunny.Repository.Schema;
using System.Collections.Generic;

namespace Bunny.Repository.Interface
{
    public interface IRestaurantRepository
    {
        int Insert(RestaurantModel obj);
        RestaurantModel Select(int id);
        List<RestaurantModel> SelectList();
    }
}
