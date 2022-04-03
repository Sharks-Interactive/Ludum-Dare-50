using UnityEngine;

namespace Chrio.Entities
{
    public enum RoomType
    {
        None,
        Power,
        Water,
        Defense,
        Bunks
    }

    [CreateAssetMenu(menuName = "Data/Room", fileName = "New Room")]
    public class RoomData : EntityData, ITooltipHander
    {
        public Sprite BuildPicture;

        public RoomType RoomType;

        public float Power;

        public float Water;

        public int CitizensRequirement;

        public string Title => DisplayName;

        public string Description => $"{ShortDescription} \n \n Power: {Power} \n Water: {Water}";
    }
}
