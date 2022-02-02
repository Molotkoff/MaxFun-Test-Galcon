using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace Molotkoff.Galcon
{
    public class Planet : MonoBehaviour
    {
        public event Action<int> OnShipCountChanged;
        public event Action<Handler> OnHandlerChanged;

        [SerializeField]
        private int shipsCount;
        [SerializeField]
        private Handler handler;

        public float Radius => 1;

        private Planets planets;

        public Handler Handler 
        { 
            get => handler;
            set 
            {
                planets?.Remove(this);
                handler = value;
                planets = PlanetsOf(value);
                planets.Add(this);

                OnHandlerChanged?.Invoke(value);
            }
        }
        
        public int Ships 
        { 
            get => shipsCount;
            set 
            {
                shipsCount = value;
                OnShipCountChanged?.Invoke(value);
            } 
        }

        private Planets PlanetsOf(Handler handler)
        {
            switch (handler)
            {
                case Handler.Player:
                    return AllPlanets.Instance.Player;
                case Handler.Enemy:
                    return AllPlanets.Instance.Enemy;
                case Handler.Neutral:
                    return AllPlanets.Instance.Neutral;
            }

            return null;
        }
    }
}