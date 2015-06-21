using System.Collections.Generic;
using CoffeeMachine.Models;
using CoffeeMachine.Properties;

namespace CoffeeMachine.Controllers
{
    class LandscapeController
    {
        public List<Landscape> Landscapes
        {
            get
            {
                return GetAllLandscapes();
            }
        }
        private List<Landscape> GetAllLandscapes()
        {
            List<Landscape> landscapes = new List<Landscape>{
                new Landscape { Name = "Alps", Image = Resources.LandscapesImageFolder + "Alps.png" },
                new Landscape { Name = "BamboForest", Image = Resources.LandscapesImageFolder + "BamboForest.png" },
                new Landscape { Name = "Hitachi", Image = Resources.LandscapesImageFolder + "Hitachi.png" },
                new Landscape { Name = "ParisNights", Image = Resources.LandscapesImageFolder + "ParisNights.png" },
                new Landscape { Name = "Bos", Image = Resources.DrinksImageFolder + "Coffee1.png" },
                new Landscape { Name = "Strand", Image = Resources.DrinksImageFolder + "Coffee1.png" }
            };

            return landscapes;
        } 
    }
}
