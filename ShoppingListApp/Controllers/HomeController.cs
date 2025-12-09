using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Models;
using System.Collections.Generic;
using System.Linq; 

namespace ShoppingListApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Apple", Price = 0.50m, ImageUrl = "/Images/apple.png" },
            new Item { Id = 2, Name = "Banana", Price = 0.25m, ImageUrl = "/Images/banana.png" },
            new Item { Id = 3, Name = "Orange", Price = 0.75m, ImageUrl = "/Images/orange.png" },
        };

       
        public IActionResult Index()
        {
            return View(_items);
        }

        
        [HttpGet]
        public IActionResult GetItemDetails(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                return NotFound();
            }

            
            return Json(new { price = item.Price, imageUrl = item.ImageUrl });
        }
    }
}