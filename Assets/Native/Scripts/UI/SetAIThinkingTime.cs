using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Molotkoff.Galcon
{
    public class SetAIThinkingTime : MonoBehaviour
    {
        [SerializeField]
        private AIData ai;
        [SerializeField]
        private Slider slider;

        public void Set(float _)
        {
            ai.thinkingTime = slider.value;
        }
    }
}