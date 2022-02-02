using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Molotkoff.Galcon
{
    [RequireComponent(typeof(Planet))]
    public class PlanetClickeable : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnSelecet;
        public event Action OnDeselect;

        [SerializeField]
        private float selectionTime;

        private Planet model;

        private InputModel input;

        private bool isSelected = false;
        private float time = 0;

        private void Awake()
        {
            model = GetComponent<Planet>();
            input = InputModel.Instance;
        }

        private void FixedUpdate()
        {
            if (isSelected)
            {
                time += Time.deltaTime;

                if (time >= selectionTime)
                {
                    isSelected = false;
                    time = 0;

                    OnDeselect?.Invoke();
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Action[User-Planet-Click]");

            if (model.Handler == Handler.Player)
            {
                isSelected = true;
                time = 0;

                OnSelecet?.Invoke();
            }

            input.InputSelect(model);
        }
    }
}