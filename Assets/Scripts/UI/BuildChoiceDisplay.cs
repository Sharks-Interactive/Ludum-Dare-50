using Chrio.World;
using Chrio.World.Loading;
using UnityEngine.UI;
using Chrio.Entities;

namespace Chrio.UI
{
    public class BuildChoiceDisplay : SharksBehaviour
    {
        public struct UIElements
        {
            public Image Picture;
        }

        private UIElements Elements = new();

        public RoomData Data { get => _data; set { _data = value; UpdateUI(); } }
        private RoomData _data;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            Elements.Picture = transform.Find("Choice Image").GetComponentInChildren<Image>();
        }

        private void UpdateUI() { if (Elements.Picture == null) Elements.Picture = transform.Find("Choice Image").GetComponentInChildren<Image>();  Elements.Picture.sprite = _data.BuildPicture; }
    }
}
