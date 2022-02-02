using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class SetAITypeView : MonoBehaviour
    {
        [SerializeField]
        private AIType AI;
        [SerializeField]
        private AIData ai;

        public void Set()
        {
            ai.AI = AI;
        }
    }
}