using Chrio.Entities;
using Chrio.World;
using System.Collections.Generic;
using SharkUtils;
using UnityEngine;

namespace Chrio
{
    public class ResourceManager
    {
        public struct Resources
        {
            public float Power;
            public float Water;
            public int Citizens;

            public static Resources operator -(Resources a, Resources b) => new Resources() { Power = a.Power - b.Power, Water = a.Water - b.Water, Citizens = a.Citizens - b.Citizens };
        }

        public Resources GlobalResources;
        private Game_State.State GlobalState;
        private Resources _lastResources;
        private int _lastRooms;

        public ResourceManager(Game_State.State _state)
        {
            GlobalState = _state;
        }

        public void CalculateResources()
        {
            Stack<Worker> _workers = new(GlobalState.Game.Workers.VaultWorkers);

            foreach (BaseRoom room in GlobalState.Game.Construction.Rooms.Values)
            {
                GlobalResources.Power += room.GetPower();
                GlobalResources.Water += room.GetWater();

                if (NeedWorkersRecalc)
                {
                    room.UnallocateAllWorkers();
                    // Change in the number of workers or rooms
                    int _numOfWorkers = (GlobalResources.Citizens < room.GetWorkersRequest() ? GlobalResources.Citizens : room.GetWorkersRequest());
                    for (int i = 0; i < _numOfWorkers; i++)
                    {
                        _workers.Pop().SendToSquare(GlobalState.Game.GridManager.GridSquareForPosition(room.transform.position));
                        room.AllocateWorkers(1);
                        GlobalResources.Citizens -= 1;
                    }
                }
            }

            _lastResources = GlobalResources;
            _lastRooms = GlobalState.Game.Construction.Rooms.Count;
        }

        private bool NeedWorkersRecalc { get => _lastResources.Citizens != GlobalResources.Citizens || _lastRooms != GlobalState.Game.Construction.Rooms.Count;  }
    }
}
