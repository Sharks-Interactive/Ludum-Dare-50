using UnityEngine;
using static Chrio.World.Game_State;
using Chrio.World.Loading;

namespace Chrio
{
    /// <summary>
    /// Purpose: Base class for all Shark's Interactive script behaviours
    /// </summary>
    public class SharksBehaviour : MonoBehaviour, ILoadableObject
    {
        protected State GlobalState;

        public virtual void OnLoad(State _gameState, ILoadableObject.CallBack _callback)
        {
            GlobalState = _gameState;
            _callback();
        }
    }
}
