using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class DummyAI : MonoBehaviour
    {
        [SerializeField]
        private AIData ai;

        private float time;

        private InputModel playerInput;
        private AllPlanets planets;

        private void Awake()
        {
            playerInput = InputModel.Instance;
            planets = AllPlanets.Instance;
        }

        private void Start()
        {
            var planets = AllPlanets.Instance;

            playerInput.OnPlayerSetDestinationPlanet += (destination, ships) => 
            {
                if (destination.Handler == Handler.Neutral)
                {
                    var biggest = FindBiggestPlanet(planets.Enemy);

                    if (biggest != null)
                    {
                        if (biggest.Ships / 2 > ships)
                        {
                            ShipsUtil.CreateShips(biggest, destination);
                        }
                    }
                }
                else if (destination.Handler == Handler.Enemy && ai.AI == AIType.Defensive)
                {
                    var biggest = FindBiggestPlanet(planets.Enemy);

                    if (biggest != destination)
                    {
                        ShipsUtil.CreateShips(biggest, destination);
                    }
                }
            };
        }

        private void FixedUpdate()
        {
            time += Time.deltaTime;

            if (time >= ai.thinkingTime)
            {
                if (planets.Neutral.All.Count > 0 && ai.AI == AIType.Defensive)
                {
                    var smallest = FindSmallestPlanet(planets.Neutral);

                    if (smallest != null)
                    {
                        var biggest = FindBiggestPlanet(planets.Enemy);

                        if (biggest != null)
                            ShipsUtil.CreateShips(biggest, smallest);
                    }
                }
                else if (planets.Player.All.Count > 0)
                {
                    var smallest = FindSmallestPlanet(planets.Player);

                    if (smallest != null)
                    {
                        var biggest = FindBiggestPlanet(planets.Enemy);

                        if (biggest != null)
                            ShipsUtil.CreateShips(biggest, smallest);
                    }
                }

                time = 0;
            }
        }

        private Planet FindSmallestPlanet(Planets planets)
        {
            if (planets.All.Count > 0)
            {
                var found = planets.All[0];

                for (int i = 1; i < planets.All.Count; i++)
                {
                    if (planets.All[i].Ships < found.Ships)
                        found = planets.All[i];
                }

                return found;
            }

            return null;
        }

        private Planet FindBiggestPlanet(Planets planats) 
        {
            if (planats.All.Count > 0)
            {
                var found = planats.All[0];

                for (int i = 1; i < planats.All.Count; i++)
                {
                    if (planats.All[i].Ships > found.Ships)
                        found = planats.All[i];
                }

                return found;
            }

            return null;
        }
    }
}