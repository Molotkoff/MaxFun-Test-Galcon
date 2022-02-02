using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class Map : MonoBehaviour
    {
        [SerializeField]
        private MapGeneratorData mapGeneratorData;

        private void Start()
        {
            var mapGenerator = mapGeneratorData.MapGenerator;

            var map = mapGenerator.Create();
            map.transform.SetParent(transform);
        }
    }
}