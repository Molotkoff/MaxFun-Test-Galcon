using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    [RequireComponent(typeof(Planet))]
    public class ShipsGenerator : MonoBehaviour
    {
        [SerializeField]
        private float onTime;
        [SerializeField]
        private int shipsCount;

        private Planet planet;

        private float time;

        private void Awake()
        {
            planet = GetComponent<Planet>();
        }

        private void FixedUpdate()
        {
            if (planet.Handler != Handler.Neutral)
            {
                time += Time.deltaTime;

                if (time >= onTime)
                {
                    planet.Ships += shipsCount;
                    time = 0;
                }
            }
        }
    }
}