using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    [CreateAssetMenu(menuName = "Galcon/HandlerColors")]
    public class HandlerColors : ScriptableObject
    {
        [SerializeField]
        private Color player, enemy, neutral;

        public Color Player => player;
        public Color Enemy => enemy;
        public Color Neutral => neutral;
    }
}