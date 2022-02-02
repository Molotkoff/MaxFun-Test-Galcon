using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molotkoff.Galcon
{
    public class Planets
    {
        public event Action<Planet> OnAdd;
        public event Action<Planet> OnRemove;

        private List<Planet> planets = new List<Planet>();

        public void Add(Planet planet)
        {
            if (!planets.Contains(planet))
            {
                planets.Add(planet);
                OnAdd?.Invoke(planet);
            }
        }

        public void Remove(Planet planet)
        {
            if (planets.Remove(planet))
                OnRemove?.Invoke(planet);
        }

        public List<Planet> All => planets;
    }
}