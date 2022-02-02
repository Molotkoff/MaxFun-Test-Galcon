using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class ShipsUtil
    {
        public static int CreateShips(Planet from, Planet destination)
        {
            if (from.Ships > 0)
            {
                var ships = from.Ships / 2;
                if (ships == 0)
                    ships = 1;

                from.Ships -= ships;

                for (int i = 0; i < ships; i++)
                    Ships.Create(from, destination);

                return ships;
            }

            return 0;
        }
    }
}