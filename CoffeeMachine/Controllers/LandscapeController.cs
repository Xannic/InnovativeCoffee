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
                new Landscape { Name = "Italie", Image = Resources.LandscapesImageFolder + "Italie.png" },
                new Landscape { Name = "Venetie", Image = Resources.LandscapesImageFolder + "Venetie.png" }
            };

            return landscapes;
        } 
    }
}
