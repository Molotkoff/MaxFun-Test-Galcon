using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Molotkoff.Galcon
{
    public class ShipAI : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent agent;
        [SerializeField]
        private Ship ship;

        private void Awake()
        {
            ship.OnPlanetDestinationChanged += SetDestination;
        }

        private void OnDestroy()
        {
            ship.OnPlanetDestinationChanged -= SetDestination;
        }

        private void SetDestination(Planet planet)
        {
            agent.SetDestination(planet.transform.position);
        }
    }
}