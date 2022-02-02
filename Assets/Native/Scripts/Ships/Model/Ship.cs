using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Molotkoff.Galcon
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Ship : MonoBehaviour
    {
        public event Action<Planet> OnPlanetDestinationChanged;
        public event Action<Handler, Planet> OnPlanetDestinationArrived;
        public event Action<Handler> OnHandlerChanged;

        private Handler fromHandler;
        private Planet destinationPlanet;

        public void Setup(Planet from, Planet destination)
        {
            var diffusePosition = UnityEngine.Random.insideUnitCircle * from.Radius;
            transform.position = from.transform.position + new Vector3(diffusePosition.x, 0, diffusePosition.y);
            fromHandler = from.Handler;
            destinationPlanet = destination;

            OnPlanetDestinationChanged?.Invoke(destination);
            OnHandlerChanged?.Invoke(fromHandler);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<Planet>(out var planet))
            {
                if (planet == destinationPlanet)
                {
                    OnPlanetDestinationArrived?.Invoke(fromHandler, destinationPlanet);

                    Ships.Return(this);
                }
            }
        }
    }
}