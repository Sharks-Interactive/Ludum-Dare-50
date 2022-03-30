using Chrio.Entities;
using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using static Chrio.World.Game_State;

namespace Chrio.Player
{
    public class BasePlayer : BaseEntity
    {
        protected Rigidbody2D rb;
        public AudioSource src;

        public State State { get => GlobalState; }

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            rb = GetComponent<Rigidbody2D>();
            src = GetComponent<AudioSource>();
        }
    }
}
