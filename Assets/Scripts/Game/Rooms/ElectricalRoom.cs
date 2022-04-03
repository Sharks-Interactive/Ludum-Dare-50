using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chrio.Entities
{
    public class ElectricalRoom : BaseRoom
    {
        public override float GetPower()
        {
            return RoomData.Power / (RoomData.CitizensRequirement - Workers); // Reduce efficiency if we don't have 100% worker assignment
        }
    }
}
