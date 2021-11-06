using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() {Id=1,Name="Dominos",Location="Johar, Kamran Chowrangi", Cuisine=CuisineType.Mexican  }
,
                new Restaurant() {
                    Id=2,Name="Pizza Hut", Location="Johar, University Road",Cuisine=CuisineType.None
                }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) ||
                    r.Name.StartsWith(name) || r.Name.EndsWith(name)
                   select r;
        }

        public Restaurant GetRestaurantDetail(int id)
        {
            return restaurants.Where(x => x.Id == id).SingleOrDefault();
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var obj = restaurants.SingleOrDefault(x => x.Id == restaurant.Id);
            if (obj != null)
            {
                obj.Location = restaurant.Location;
                obj.Name = restaurant.Name;
                obj.Cuisine = restaurant.Cuisine;
            }

            return obj;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(x => x.Id);
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var obj = restaurants.SingleOrDefault(x => x.Id == id);
            if (obj != null)
            {
                restaurants.Remove(obj);
            }

            return obj;
        }
    }
}
