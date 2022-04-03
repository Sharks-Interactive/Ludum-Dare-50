using Chrio.Entities;
using Chrio.World;
using System.Collections.Generic;

namespace Chrio
{
    public class ResourceManager
    {
        public struct Resources
        {
            public float Power;
            public float Water;
            public float Citizens;

            public static Resources operator -(Resources a, Resources b) => new Resources() { Power = a.Power - b.Power, Water = a.Water - b.Water, Citizens = a.Citizens - b.Citizens };
        }

        public Resources GlobalResources;
        private Game_State.State GlobalState;

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

                for (int i = 0; i < GlobalResources.Citizens / GlobalState.Game.Construction.Rooms.Count; i++) _workers.Pop().SendToGrid();
            }
        }
    }
}
