using System.Collections.Generic;
using CoffeeMachine.Models;
using CoffeeMachine.Properties;

namespace CoffeeMachine.Controllers
{
    class DrinkController
    {
        public List<Drink> Drinks {
            get
            {
                return GetAllDrinks();
            }
        }
        private List<Drink> GetAllDrinks()
        {
            List<Drink> drinks = new List<Drink>
            {
                new Drink {Name = "Cappucinno", Image = Resources.DrinksImageFolder + "Coffee1.png"},
                new Drink {Name = "Ristretto", Image = Resources.DrinksImageFolder + "Coffee1.png"},
                new Drink {Name = "Espresso", Image = Resources.DrinksImageFolder + "Espresso.png"},
                new Drink {Name = "Variatie Coffee", Image = Resources.DrinksImageFolder + "Coffee1.png"},
                new Drink {Name = "Doubble Espresso", Image = Resources.DrinksImageFolder + "Coffee1.png"},
                new Drink {Name = "Cafe Creme", Image = Resources.DrinksImageFolder + "Coffee1.png"},
                new Drink {Name = "Warme Chocomelk", Image = Resources.DrinksImageFolder + "Chocolade.png"},
                new Drink {Name = "Thee", Image = Resources.DrinksImageFolder + "Thee.png"}
            };

            return drinks;
        } 
    }
}
