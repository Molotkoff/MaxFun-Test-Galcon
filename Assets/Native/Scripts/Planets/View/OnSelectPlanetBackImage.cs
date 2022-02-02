using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Molotkoff.Galcon
{
    public class OnSelectPlanetBackImage : MonoBehaviour
    {
        [SerializeField]
        private PlanetClickeable clickeable;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            clickeable.OnSelecet += Select;
            clickeable.OnDeselect += Deselect;

            Deselect();
        }

        private void OnDestroy()
        {
            clickeable.OnSelecet -= Select;
            clickeable.OnDeselect -= Deselect;
        }

        private void Select()
        {
            spriteRenderer.enabled = true;
        }

        private void Deselect()
        {
            spriteRenderer.enabled = false;
        }
    }
}