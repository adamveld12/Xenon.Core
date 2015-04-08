using System;
using System.Collections.Generic;

namespace Xenon.Core.States
{
    /// <summary>
    /// Manages a stack of <see cref="GameState"/>s
    /// </summary>
    public class GameStateStack : IGameStateStack
    {
        private readonly Stack<GameState> _states;

        #region Lifecycle

        /// <summary>
        /// Initializes a new instance of <see cref="GameStateStack"/>
        /// </summary>
        public GameStateStack()
        {
            _states =  new Stack<GameState>(32);
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        /// </summary>
        ~GameStateStack()
        {
            Dispose(false);
        }
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() { Dispose(true); }

        private void Dispose(bool managed)
        {
            if (managed)
            {
                GC.SuppressFinalize(this);
                while (_states.Count > 0) Pop();
            }
        }

        #endregion

        /// <summary>
        /// Activates a new <see cref="GameState"/> and pauses any underlying states
        /// </summary>
        /// <param name="newState"></param>
        public void Push(GameState newState)
        {
            if(_states.Count > 0)
                _states.Peek().Pause();


            _states.Push(newState);

            newState.OnEnter();
        }

        /// <summary>
        /// Exits the current <see cref="GameState"/> and reactivates any underlying states
        /// </summary>
        /// <returns></returns>
        public GameState Pop()
        {
            if (_states.Count > 0) { 
                var lastState = _states.Pop();
                lastState.Dispose();

                if(_states.Count > 0)
                    _states.Peek().Unpause();

                return lastState;
            }

            return null;
        }

        /// <summary>
        /// Updates the game states
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            _states.ForEach(state => state.Update(gameTime));
        }

        /// <summary>
        /// Renders the game states
        /// </summary>
        /// <param name="gameTime"></param>
        public void Render(GameTime gameTime)
        {
            _states.ForEach(state => state.Render(gameTime));
        }
    }
}
