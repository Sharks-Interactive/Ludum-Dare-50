using UnityEngine;

namespace Chrio.Entities
{
    /// <summary>
    /// Purpose: Interface for manipulating and receiving data from entities
    /// </summary>
    public interface IBaseEntity
    {
        public void OnSelected();

        public void WhileSelected();

        public void OnDeselected();

        public BaseEntity GetEntity();

        public EntityData GetData();

        public GameObject GetGameObject();

        public string GetEntityType();

        public bool CompareEntityType(string EntType);
    }
}
