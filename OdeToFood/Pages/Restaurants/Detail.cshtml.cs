using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {


        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetRestaurantById(id);

            if (Restaurant == null)
            {
                return RedirectToPage("../Error");
            }
            else
            {
                return Page();
            }
        }
    }

}
