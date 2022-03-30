using Chrio.World;
using Chrio.World.Loading;
using SharkUtils;
using UnityEngine;

namespace Chrio.Effects
{
    /// <summary>
    /// Purpose: Parrallax effect
    /// </summary>
    public class Parrallax : SharksBehaviour
    {
        /// <summary>
        /// How strong is the parrallax
        /// </summary>
        public float ParrallaxFactor;
        /// <summary>
        /// Offset amount to add to the parrallax
        /// </summary>
        public Vector3 Offset;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);
            enabled = !_gameState.LowQuality;
        }

        private void Update() => transform.position = ((GlobalState.Game.MainCamera.transform.position * ParrallaxFactor).UpdateAxisEuler(0, ExtraFunctions.Axis.Z)) + Offset;

        private void OnDrawGizmosSelected() => transform.position = Offset;
    }
}
