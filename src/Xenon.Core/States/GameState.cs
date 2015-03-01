using System;

namespace Xenon.Core.States
{
    /// <summary>
    /// Represents a Game State
    /// </summary>
    public abstract class GameState : IDisposable
    {
        #region Lifecycle 

        /// <summary>
        /// Initializes a new instance of <see cref="GameState"/>
        /// </summary>
        protected GameState()
        {
            Exited = true;
            Paused = false;
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        /// </summary>
        ~GameState() { Dispose(false); }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() { Dispose(true); }

        private void Dispose(bool managed)
        {
            if (managed)
            {
                GC.SuppressFinalize(this);
                if(!Exited)
                    Exit();
            }
        }

        #endregion

        /// <summary>
        /// When this state is started for the first time
        /// </summary>
        public void Enter()
        {
            Exited = false;
            OnEnter();
        }

        /// <summary>
        /// When this state is exiting
        /// </summary>
        public void Exit()
        {
            Exited = true;
            OnExit();
        }

        /// <summary>
        /// When this state is deactivated
        /// </summary>
        public void Pause()
        {
            Paused = true;
            OnPause();
        }

        /// <summary>
        /// When this state is reactivated
        /// </summary>
        public void Unpause()
        {
            Paused = false;
            OnUnpause();
        }

        /// <summary>
        /// When this state is started for the first time
        /// </summary>
        public abstract void OnPause();

        /// <summary>
        /// When this state is exiting
        /// </summary>
        public abstract void OnUnpause();

        /// <summary>
        /// When this state is started for the first time
        /// </summary>
        public abstract void OnEnter();

        /// <summary>
        /// When this state is exiting
        /// </summary>
        public abstract void OnExit();

        /// <summary>
        /// Updates this state
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws this state
        /// </summary>
        public virtual void Render(GameTime gameTime) { }

        /// <summary>
        /// Gets if this <see cref="GameState"/> is active
        /// </summary>
        public bool Active
        {
            get { return !(Paused || Exited); }
        }

        /// <summary>
        /// Gets if this <see cref="GameState"/> has been asked to pause by its manager
        /// </summary>
        public bool Paused { get; private set; }

        /// <summary>
        /// Gets if this <see cref="GameState"/> has been signaled to exit
        /// </summary>
        public bool Exited { get; private set; }

    }
}
