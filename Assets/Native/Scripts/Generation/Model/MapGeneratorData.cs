using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    [CreateAssetMenu(menuName = "Galcon/Map/Data")]
    public class MapGeneratorData : ScriptableObject
    {
        public AMapGenerator MapGenerator;
    }
}