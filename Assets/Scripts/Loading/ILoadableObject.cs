namespace Chrio.World.Loading
{
    /// <summary>
    /// Purpose: Base class for loadable objects
    /// </summary>
    public interface ILoadableObject
    {
        public delegate void CallBack();

        /// <summary>
        /// Called when the game is on the loading screen, use for
        /// heavily resource intensive or asynchronous functions
        /// Call the callback to let the loader know loading is complete
        /// </summary>
        /// <param name="_callback"> The completion callback </param>
        void OnLoad(Game_State.State _gameState, CallBack _callback);
    }
}
