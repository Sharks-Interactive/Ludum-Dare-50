using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chrio.Entities
{
    public class BaseRoom : BaseEntity
    {
        protected override string EntityType { get => "Room"; }

        public virtual void OnPlace() { }
    }
}
