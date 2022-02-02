using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molotkoff.Galcon
{
    public class InputModel : Singleton<InputModel>
    {
        public event Action<Planet> OnPlayerSetFromPlanet;
        public event Action<Planet, int> OnPlayerSetDestinationPlanet;

        private Planet from;

        public void InputSelect(Planet planet)
        {
            if (from == null && planet.Handler == Handler.Player)
            {
                from = planet;
                OnPlayerSetFromPlanet?.Invoke(from);
                return;
            }

            if (from != null && from.Ships > 0 && planet != from)
            {
                var ships = ShipsUtil.CreateShips(from, planet);

                if (ships > 0)
                {
                    OnPlayerSetDestinationPlanet?.Invoke(planet, ships);
                    from = null;
                }
            }
        }
    }
}