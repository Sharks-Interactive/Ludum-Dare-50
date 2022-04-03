using UnityEngine;
using TMPro;
using Chrio.World;
using Chrio.World.Loading;
using SharkUtils;

namespace Chrio.UI
{
    public class TooltipManager : SharksBehaviour
    {
        private struct UIElements
        {
            public TextMeshProUGUI Title;
            public TextMeshProUGUI Desc;
            public CanvasGroup Group;
        }

        private UIElements _elements;

        public struct TooltipData
        {
            public string Title;
            public string Desc;
        }

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _elements.Desc = transform.Find("Desc").GetComponent<TextMeshProUGUI>();
            _elements.Title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
            _elements.Group = GetComponent<CanvasGroup>();

            GlobalState.Game.Tooltip = this;
        }

        public void ShowTooltip(TooltipData Data)
        {
            _elements.Title.text = Data.Title;
            _elements.Desc.text = Data.Desc;

            _elements.Group.SetVisible(true);
        }

        public void HideTooltip() => _elements.Group.SetVisible(false);
    }
}
