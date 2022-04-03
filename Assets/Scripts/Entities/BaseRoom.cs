using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chrio.Entities
{
    public class BaseRoom : BaseEntity
    {
        protected override string EntityType { get => "Room"; }
        public override EntityData EntityData { get => RoomData; }
        public RoomData RoomData;

        public int Workers;

        public virtual void AllocateWorkers(int Workers) { this.Workers += Workers; }

        public virtual void RetrieveWorkers(int Workers) { this.Workers -= Workers; }

        public virtual int GetWorkersRequest() => RoomData.CitizensRequirement;

        public virtual void OnPlace() { }

        public virtual float GetPower() { return loaded ? RoomData.Power : 0;  }

        public virtual float GetWater() { return loaded ? RoomData.Water : 0; }
    }
}
