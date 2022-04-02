using Chrio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Chrio.World
{
    public class RoomPlacer : SharksBehaviour
    {
        public GameObject Ghost;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Ghost.SetActive(GlobalState.Game.Construction.Placing == Game_State.Construction.PlacingType.None);

            switch (GlobalState.Game.Construction.Placing)
            {
                case Game_State.Construction.PlacingType.Power:
                    Ghost.transform.position = GlobalState.Game.GridManager.GridPosition;
                    break;

                default:
                    return;
            }
        }
    }
}
