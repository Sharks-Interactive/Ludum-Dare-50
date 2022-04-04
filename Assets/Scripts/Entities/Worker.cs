using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using SharkUtils;

namespace Chrio.Entities
{
    public class Worker : SharksBehaviour
    {
        private Animator _walkingAnimator;

        public float Speed = 5.0f;
        public float Padding = 2;
        public float DistanceRequirement = 0.1f;

        private Vector2 _lastPosition;
        private Vector2[] _goals;
        private int _goal = 1;

        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            _walkingAnimator = GetComponent<Animator>();

            // Init goals system
            _goals = new Vector2[2];
            

            GlobalState.Game.Workers.AddWorker(GlobalState, this);
        }

        public void SendToSquare(Vector2 GridSquare) 
        {
            Vector2 _gridPos = GlobalState.Game.GridManager.GridPositionForSquare(GridSquare);
            _gridPos.y = _gridPos.y - (GlobalState.Game.GridManager.GridSize.y / Padding);
            _goals[0] = new Vector2(_gridPos.x - (GlobalState.Game.GridManager.GridSize.x / Padding), _gridPos.y);
            _goals[1] = new Vector2(_gridPos.x + (GlobalState.Game.GridManager.GridSize.x / Padding), _gridPos.y);

            transform.position = _goals[0];
        }

        private void Update()
        {
            _walkingAnimator.SetBool("FacingRight", transform.position.x - _lastPosition.x > 0);
            _lastPosition = transform.position;

            if (Vector2.Distance(transform.position, _goals[_goal]) < DistanceRequirement) _goal = (_goal == 1 ? 0 : 1); // Swap goal

            // Move towards goals
            Vector2 _dir = (_goals[_goal] - (Vector2)transform.position).normalized;
            transform.Translate(Speed * Random.Range(0.8f, 1.5f) * Time.deltaTime * _dir, Space.World);

            transform.position = transform.position.UpdateAxisEuler(0, ExtraFunctions.Axis.Z);
        }
    }
}
