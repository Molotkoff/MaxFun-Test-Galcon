using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class AllPlanets : Singleton<AllPlanets>
    {
        private Planets player  = new Planets();
        private Planets enemy   = new Planets();
        private Planets neutral = new Planets();

        public Planets Player => player;
        public Planets Enemy => enemy;
        public Planets Neutral => neutral;
    }
}