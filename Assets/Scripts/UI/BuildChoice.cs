using UnityEngine;
using Chrio.Entities;
using Chrio.World;
using Chrio.World.Loading;
using UnityEngine.EventSystems;

namespace Chrio.UI
{
    [RequireComponent(typeof(BuildChoiceDisplay))]
    public class BuildChoice : SharksBehaviour, ITooltipHander
    {
        public RoomData Data { get => _data; set { _data = value; Refresh(); } }

        public string Title { get => _data.Title; }
        public string Description { get => _data.Description; }

        private RoomData _data;
        private BuildChoiceDisplay _display;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _display = GetComponent<BuildChoiceDisplay>();
        }

        public void Refresh()
        {
            if (_display == null) _display = GetComponent<BuildChoiceDisplay>();
            _display.Data = _data;
        }

        public void SetPlacing()
        {
            GlobalState.Game.Construction.Placing = _data.RoomType;
            GlobalState.Game.Construction.PlacingData = _data;
        }
    }
}
