using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Chrio
{
    public class GridManager : SharksBehaviour
    {
        public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
        {
            base.OnLoad(_gameState, _callback);

            GlobalState.Game.GridManager = this;
        }

        public Vector2 GridSize;

        public Vector2 MousePosition { get => GlobalState.Game.MainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()); }

        public Vector2 GridSquare
        {
            get
            {
                return new Vector2(
                    Mathf.Round(MousePosition.x / GridSize.x),
                    Mathf.Round(MousePosition.y / GridSize.y)
                );
            }
        }

        public Vector3 GridPosition
        {
            get
            {
                return new Vector3(
                     GridSquare.x * GridSize.x,
                     GridSquare.y * GridSize.y,
                     0
                );
            }
        }

        public Vector2 GridSquareForPosition(Vector2 Position) => new Vector2(
            Mathf.Round(Position.x / GridSize.x),
            Mathf.Round(Position.y / GridSize.y)
        );

        /// <summary>
        /// Returns the worldposition of the center of a given gridsquare
        /// </summary>
        /// <param name="GridSquare"> Which square are we taling about</param>
        /// <returns> World position of the center of the requested grid square </returns>
        public Vector3 GridPositionForSquare(Vector2 GridSquare) => new Vector3(
            GridSquare.x * GridSize.x,
            GridSquare.y * GridSize.y,
            0
        );
    }
}
