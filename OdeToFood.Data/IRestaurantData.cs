using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantByName(string name);

        Restaurant GetRestaurantById(int id);

        Restaurant UpdateRestaurant(Restaurant restaurant);

        Restaurant AddRestaurant(Restaurant restaurant);

        Restaurant DeleteRestaurant(int id);

        int Commit();

        int Count();


    }
}
