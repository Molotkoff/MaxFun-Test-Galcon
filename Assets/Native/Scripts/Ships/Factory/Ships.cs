using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class Ships : MonoBehaviour
    {
        [SerializeField]
        private Ship shipPrefab;

        private Pool<Ship> ships;

        private static Ships instance;

        private void Awake()
        {
            instance = this;

            ships = new Pool<Ship>(() =>
            {
                var ship = Instantiate(shipPrefab);
                ship.transform.parent = transform;
                ship.gameObject.SetActive(false);

                return ship;
            }); 
        }

        public static Ship Create(Planet fromPlanet, Planet destinationPlanet)
        {
            var ship = instance.ships.Item;

            ship.gameObject.SetActive(true);
            ship.Setup(fromPlanet, destinationPlanet);

            return ship;
        }

        public static void Return(Ship ship)
        {
            ship.gameObject.SetActive(false);

            instance.ships.Item = ship;
        }
    }
}