using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            RestaurantData = restaurantData;
            HtmlHelper = htmlHelper;
        }

        public IRestaurantData RestaurantData { get; }
        public IHtmlHelper HtmlHelper { get; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Restaurant = RestaurantData.GetRestaurantById(id.Value);
                if (Restaurant == null)
                {
                    return RedirectToPage("../Error");
                }
            }
            else
            {
                Restaurant = new Restaurant();
            }

            Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            try
            {
                if (Restaurant.Id > 0)
                {
                    RestaurantData.UpdateRestaurant(Restaurant);
                }
                else
                {
                    RestaurantData.AddRestaurant(Restaurant);
                }

                RestaurantData.Commit();
                
                TempData["Message"] = "Restaurant Saved!";
                return RedirectToPage("./List");
            }
            catch (System.Exception)
            {
                return RedirectToPage("../Error");
            }

        }
    }
}
