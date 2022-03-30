using UnityEngine;

namespace Chrio.Entities
{
    [CreateAssetMenu(fileName = "New Entity", menuName = "Data/Entity")]
    public class EntityData : ScriptableObject
    {
        [Tooltip("Human name for this entity")]
        [TextArea(3, 10)]
        public string DisplayName;

        [Tooltip("One line description for this entity")]
        [TextArea(3, 10)]
        public string ShortDescription;
    }
}
