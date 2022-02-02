using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    [RequireComponent(typeof(Planet))]
    public class PlanetSetup : MonoBehaviour
    {
        [SerializeField]
        private PlanetSettings planetSettings;

        private Planet planet;

        private void Awake()
        {
            planet = GetComponent<Planet>();    
        }

        private void Start()
        {
            var planets = AllPlanets.Instance;

            switch (planet.Handler)
            {
                case Handler.None:
                    if (planets.Player.All.Count == 0)
                        SetupPlayerPlanet(planets);
                    else if (planets.Enemy.All.Count == 0)
                        SetupEnemyPlanet(planets);
                    else
                        SetupNeutralPlanet(planets);
                    break;
                case Handler.Enemy:
                    SetupEnemyPlanet(planets);
                    break;
                case Handler.Neutral:
                    SetupNeutralPlanet(planets);
                    break;
                case Handler.Player:
                    SetupPlayerPlanet(planets);
                    break;
            }
        }

        private void SetupEnemyPlanet(AllPlanets planets)
        {
            planet.Handler = Handler.Enemy;
            planet.Ships = planetSettings.playerNEnemyShipCount;

            planets.Enemy.Add(planet);
        }

        private void SetupPlayerPlanet(AllPlanets planets)
        {
            planet.Handler = Handler.Player;
            planet.Ships = planetSettings.playerNEnemyShipCount;

            planets.Player.Add(planet);
        }

        private void SetupNeutralPlanet(AllPlanets planets)
        {
            planet.Handler = Handler.Neutral;

            var minShips = planetSettings.minNeutralShipCount;
            var maxShips = planetSettings.maxNeutralShipCount;
            planet.Ships = UnityEngine.Random.Range(minShips, maxShips);

            planets.Neutral.Add(planet);
        }
    }
}