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
                new Drink {Name = "Cappucinno", Image = Resources.DrinksImageFolder + "Cappucino.png"},
                new Drink {Name = "Ristretto", Image = Resources.DrinksImageFolder + "Risirette.png"},
                new Drink {Name = "Espresso", Image = Resources.DrinksImageFolder + "Espresso.png"},
                new Drink {Name = "Water", Image = Resources.DrinksImageFolder + "Water.png"},
                new Drink {Name = "Double Espresso", Image = Resources.DrinksImageFolder + "DoubleEspresso.png"},
                new Drink {Name = "Variatie Koffie", Image = Resources.DrinksImageFolder + "VariatieKoffie.png"},
                new Drink {Name = "Warme Chocomelk", Image = Resources.DrinksImageFolder + "Chocolade.png"},
                new Drink {Name = "Thee", Image = Resources.DrinksImageFolder + "Thee.png"}
            };

            return drinks;
        } 
    }
}
