using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class ShipCountTextView : MonoBehaviour
    {
        [SerializeField]
        private TextMesh text;
        [SerializeField]
        private Planet planet;

        private void OnEnable()
        {
            planet.OnShipCountChanged += UpdateText;
        }

        private void OnDisable()
        {
            planet.OnShipCountChanged -= UpdateText;
        }

        private void UpdateText(int ships)
        {
            text.text = ships.ToString();
        }
    }
}
