using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class PresetMapGenerator : AMapGenerator
    {
        [SerializeField]
        private GameObject[] presets;

        public override GameObject Create()
        {
            var index = UnityEngine.Random.Range(0, presets.Length);
            var preset = presets[index];

            return Instantiate(preset);
        }
    }
}