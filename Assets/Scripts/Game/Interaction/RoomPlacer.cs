using UnityEngine;
using Chrio.Entities;
using UnityEngine.InputSystem;

namespace Chrio.World
{
    public class RoomPlacer : SharksBehaviour
    {
        public GameObject Ghost;

        void Update()
        {
            Ghost.SetActive(GlobalState.Game.Construction.Placing != RoomType.None);

            switch (GlobalState.Game.Construction.Placing)
            {
                case RoomType.Power:
                    Ghost.transform.position = GlobalState.Game.GridManager.GridPosition;
                    break;

                default:
                    return;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                GlobalState.Game.Construction.AddRoom(
                    GlobalState, 
                    Instantiate(
                        Resources.Load<GameObject>($"Rooms/{GlobalState.Game.Construction.Placing} Room"),
                        Ghost.transform.position, 
                        Quaternion.identity, 
                        transform
                ));
                GlobalState.Game.Construction.Placing = RoomType.None;
            }
        }
    }
}
