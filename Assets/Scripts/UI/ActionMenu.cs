using UnityEngine;
using SharkUtils;
using UnityEngine.InputSystem;
using Chrio.World;
using Chrio.World.Loading;

namespace Chrio.UI
{
    public class ActionMenu : SharksBehaviour
    {
        private CanvasGroup _canvas;

        public void ToggleMenu(CanvasGroup Canvas) => Canvas.ToggleVisible();

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _canvas = GetComponent<CanvasGroup>();
        }

        private void Update() => _canvas.SetVisible(Keyboard.current.escapeKey.isPressed);
    }
}
