using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    [CreateAssetMenu(menuName = "Galcon/PlanetSettings")]
    public class PlanetSettings : ScriptableObject
    {
        public int minNeutralShipCount;
        public int maxNeutralShipCount;
        public int playerNEnemyShipCount;
    }
}