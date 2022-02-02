using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Molotkoff.Galcon
{
    public class Setuper
    {
        const int MAXFPSRATE = 60;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Setup()
        {
            //Application.targetFrameRate = MAXFPSRATE;
        }
    }
}