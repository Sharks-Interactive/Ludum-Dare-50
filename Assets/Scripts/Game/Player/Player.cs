using Chrio.World;
using Chrio.World.Loading;
using System;

namespace Chrio.Player
{
    [Serializable]
    public struct PlayerStats
    {
        public float Acceleration;
        public float Decceleration;
        public float MaxSpeed;
    }

    public class Player : BasePlayer
    {
        private Mover _movement;
        private ClientInteraction _interaction;

        public PlayerStats Stats;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _movement = new Mover(Stats);
            _interaction = GetComponent<ClientInteraction>();

            rb.drag = Stats.Decceleration;

            _gameState.Game.Player = this;
        }

        public virtual void FixedUpdate()
        {
            if (rb != null)
                rb.AddForce(_movement.GetMovement() * Stats.Acceleration);
        }
    }
}
