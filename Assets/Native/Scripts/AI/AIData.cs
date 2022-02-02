using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    [CreateAssetMenu(menuName = "Galcon/AI")]
    public class AIData : ScriptableObject
    {
        public float thinkingTime;
        public AIType AI;
    }
}