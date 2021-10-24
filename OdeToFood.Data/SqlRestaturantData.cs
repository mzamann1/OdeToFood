using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaturantData : IRestaurantData
    {
        public OdeToFoodDbContext _db { get; }
        public SqlRestaturantData(OdeToFoodDbContext db)
        {
            _db = db;
        }
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var obj = _db.Restaurants.Find(id);
            if (obj != null)
            {
                _db.Restaurants.Remove(obj);
            }

            return obj;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _db.Restaurants;

        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in _db.Restaurants
                   where string.IsNullOrEmpty(name) ||
                    r.Name.StartsWith(name) || r.Name.EndsWith(name)
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var entity = _db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }


        public int Commit()
        {
            _db.SaveChanges();
            return 0;

        }

        public int Count()
        {
            return _db.Restaurants.Count();
        }
    }
}
