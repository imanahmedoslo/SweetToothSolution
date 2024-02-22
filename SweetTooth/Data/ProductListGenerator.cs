using SweetTooth.Data.Models.Enums;
using SweetTooth.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
namespace SweetTooth.Data
{
    public class ProductListGenerator:ControllerBase
    {

    
    public Dictionary<string, (string Measurment, int price)> productsWithDetails = new Dictionary<string, (string Measurement, int Price)>
{
    {"Friele Frokostkaffe - 250g Ground Coffee", ("250g", 90)},
    {"Solberg & Hansen Postebyen Kaffe - 250g Whole Beans", ("250g", 100)},
    {"Kaffebrenneriet Premium Kaffe - 250g Whole Beans", ("250g", 105)},
    {"Jacobs Kronung - 500g Ground Coffee", ("500g", 110)},
    {"Starbucks Pike Place Roast - 200g Ground Coffee", ("200g", 115)},
    {"Löfbergs Lila Medium Roast - 500g Whole Beans", ("500g", 120)},
    {"Nescafé Gold - 200g Instant Coffee", ("200g", 80)},

    // Tea
    {"Twinings Earl Grey Tea - 100g, 25 Tea Bags", ("100g", 50)},
    {"Pukka Herbs Wild Apple & Cinnamon - 20 Tea Bags", ("100g", 45)}, // Assuming package weight
    {"Teapigs Mao Feng Green Tea - 15 Tea Temples", ("100g", 60)}, // Assuming package weight
    {"Clipper Organic Detox Infusion - 20 Tea Bags", ("100g", 40)}, // Assuming package weight
    {"Kusmi Tea Anastasia - 125g Loose Leaf", ("125g", 65)},
    {"Yogi Tea Classic Cinnamon Spice - 17 Tea Bags", ("100g", 55)}, // Assuming package weight
    {"Harney & Sons Paris Black Tea - 20 Sachets", ("100g", 70)}, // Assuming package weight

    // Milk and Plant-Based Alternatives
    {"Tine Helmelk - 1L Full-fat Milk", ("1L", 20)},
    {"Oatly Barista Edition Oat Milk - 1L", ("1L", 30)},
    {"Alpro Soya Milk - 1L", ("1L", 25)},
    {"Rice Dream Original Rice Milk - 1L", ("1L", 28)},
    {"Alpro Almond Unsweetened - 1L", ("1L", 32)},
    {"Koko Dairy Free Coconut Milk - 1L", ("1L", 34)},
    {"Minor Figures Oat M*lk - 1L", ("1L", 29)},
    {"Havre Gull Oat Drink - 1L", ("1L", 27)},
    {"Tine Laktosefri Lettmelk - 1L Lactose-Free Milk", ("1L", 22)},
    {"Mandeldrikk Unsweetened Almond Milk - 1L", ("1L", 33)},
    {"Soyadrikk Original Soy Milk - 1L", ("1L", 26)},
    {"Naturli’ Organic Hemp Drink - 1L", ("1L", 35)},

    // Additional Coffee and Tea Enhancers
    {"Monin Vanilla Syrup - 250ml", ("250ml", 70)},
    {"Torani Caramel Syrup - 750ml", ("750ml", 75)},
    {"DaVinci Gourmet Hazelnut Syrup - 750ml", ("750ml", 80)},
    {"Monin Chocolate Sauce - 500ml", ("500ml", 85)},
    {"Sweetbird Lemonade Syrup - 1L for Iced Teas", ("1L", 65)},
    {"Tine Kremfløte - 300ml Heavy Cream for Coffee", ("300ml", 50)},
    {"Eldorado Cinnamon Sticks - 20g for Spiced Teas", ("20g", 15)},
    {"Dr. Oetker Vanilla Sugar - 10x8g for Sweetening", ("80g", 10)}, // Assuming total package weight
    {"Cheesecake", ("item", 25)},
    {"Brownie", ("item", 15)},
    {"Apple Pie", ("item", 20)},
    {"Carrot Cake", ("item", 25)},
    {"Cinnamon Roll", ("item", 10)},
    {"Macaron", ("item", 5)}, // Assuming price per piece
    {"Tiramisu", ("item", 30)},
    {"Eclair", ("item", 12)},
    {"Pavlova", ("item", 35)},
    {"Lemon Tart", ("item", 22)},
    {"Baguette", ("item", 8)},
    {"Egg Sandwich", ("item", 18)},
    {"Chocolate Croissant", ("item", 12)},
    {"Cheese And Ham Croissant", ("item", 14)},
    {"Plain Croissant", ("item", 10)},
};

        private Random random = new Random();
        private DateTime today = DateTime.Now;
        List<ShoppingListItem> items = new List<ShoppingListItem>();
        private List<ShoppingListItem> GenerateProduct(Dictionary<string, (string measurement, int price)> productPrices, int purchaseChartId)
        {
            var items = new List<ShoppingListItem>();
            var random = new Random();
            var today = DateTime.Now;

            foreach (var product in productPrices)
            {
                int amount = random.Next(20, 51);
                MeasurmentEnum measurement = DetermineMeasurement(product.Value.measurement);

                var item = new ShoppingListItem
                {
                    ProductName = product.Key,
                    Amount = amount,
                    TotalItemPrice = product.Value.price * amount,
                    IsPurchased = false,
                    Measurement = measurement,
                    ExpiringDate = today.AddMonths(random.Next(3,6)).AddDays(random.Next(2,10)),
                    PurchaseChartId = purchaseChartId
                };
                items.Add(item);
            }

            return items;
        }

        private MeasurmentEnum DetermineMeasurement(string measurement)
        {
            // Simplified logic to determine measurement enum based on the string value
            if (measurement.Contains("g")) return MeasurmentEnum.Grams;
            if (measurement.Contains("ml") || measurement.Contains("L")) return MeasurmentEnum.Liters;
            return MeasurmentEnum.Item; // Default case
        }
        [HttpGet("GenerateProductList")]
        public ActionResult<List<ShoppingListItem>> GenerateProductList()
        {
            // Assuming a default PurchaseChartId for demonstration
           List<ShoppingListItem> ShoppingList = GenerateProduct(productsWithDetails, 0);
            return Ok(ShoppingList);
        }

        
    }
}

