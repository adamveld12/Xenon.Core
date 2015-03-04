using System;

namespace Xenon.Core.States
{
    /// <summary>
    /// Manages a stack of <see cref="GameState"/>s
    /// </summary>
    public interface IGameStateStack : IDisposable
    {
        /// <summary>
        /// Activates a new <see cref="GameState"/> and pauses any underlying states
        /// </summary>
        /// <param name="newState"></param>
        void Push(GameState newState);

        /// <summary>
        /// Exits the current <see cref="GameState"/> and reactivates any underlying states
        /// </summary>
        /// <returns></returns>
        GameState Pop();

        /// <summary>
        /// Updates the game states
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Renders the game states
        /// </summary>
        /// <param name="gameTime"></param>
        void Render(GameTime gameTime);
    }
}