using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chrio
{
    public class GameManager : SharksBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            GlobalState.Game.ResourceManager.CalculateResources();
        }
    }
}
