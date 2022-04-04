using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chrio.Entities
{
    public class ElectricalRoom : BaseRoom
    {
        public override float GetPower()
        {
            return RoomData.Power * ((float)Workers / RoomData.CitizensRequirement); // Reduce efficiency if we don't have 100% worker assignment
        }
    }
}
