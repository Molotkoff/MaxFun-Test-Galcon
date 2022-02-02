using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class PlanetChangeShipCountOnArrived : MonoBehaviour
    {
        [SerializeField]
        private Ship ship;

        private void Awake()
        {
            ship.OnPlanetDestinationArrived += ChangeShipCount;
        }

        private void OnDestroy()
        {
            ship.OnPlanetDestinationArrived -= ChangeShipCount;
        }


        private void ChangeShipCount(Handler from, Planet destination)
        {
            if (destination.Handler == from)
            {
                destination.Ships++;
            }
            else if (--destination.Ships <= 0)
            {
                destination.Handler = from;
            }
        }
    }
}