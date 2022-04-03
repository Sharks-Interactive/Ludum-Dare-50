using Chrio.World;
using Chrio.World.Loading;
using UnityEngine.EventSystems;

namespace Chrio.UI
{
    public class TooltippedObject : SharksBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private ITooltipHander _tooltipHandler;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _tooltipHandler = GetComponent<ITooltipHander>();
        }

        public void OnPointerEnter(PointerEventData eventData) => GlobalState.Game.Tooltip.ShowTooltip(new TooltipManager.TooltipData() { Title = _tooltipHandler.Title, Desc = _tooltipHandler.Description });

        public void OnPointerExit(PointerEventData eventData) => GlobalState.Game.Tooltip.HideTooltip();
    }
}
