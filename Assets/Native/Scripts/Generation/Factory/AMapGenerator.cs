using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public abstract class AMapGenerator : MonoBehaviour
    {
        public abstract GameObject Create();
    }
}