using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class ChangeShipColorOnHandler : MonoBehaviour
    {
        [SerializeField]
        private Ship ship;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private HandlerColors handlerColors;

        private void Awake()
        {
            ship.OnHandlerChanged += ChangeColor;
        }

        private void OnDestroy()
        {
            ship.OnHandlerChanged -= ChangeColor;
        }

        private void ChangeColor(Handler handler)
        {
            switch (handler)
            {
                case Handler.Neutral:
                    spriteRenderer.color = handlerColors.Neutral;
                    break;
                case Handler.Enemy:
                    spriteRenderer.color = handlerColors.Enemy;
                    break;
                case Handler.Player:
                    spriteRenderer.color = handlerColors.Player;
                    break;
            }
        }
    }
}