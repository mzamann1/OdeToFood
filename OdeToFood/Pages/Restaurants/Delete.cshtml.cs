using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restarantdata;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restarantdata)
        {
            this.restarantdata = restarantdata;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = restarantdata.GetRestaurantById(id);
            if (Restaurant == null)
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var restatuant = restarantdata.DeleteRestaurant(id);
            restarantdata.Commit();

            if (restatuant == null)
            {
                return RedirectToPage("../Error");
            }

            TempData["Message"] = $"{restatuant.Name} deleted!";
            return RedirectToPage("./List");
        }
    }
}
