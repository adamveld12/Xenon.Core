using System;

namespace Xenon.Core
{
    /// <summary>
    /// A simple component that can hook into the game loop for updates and rendering
    /// Here, I follow the Resource Acquisition Is Initialization (RAII) concept, hence no Initialize function. Use your constructor
    /// </summary>
    public abstract class GameComponent : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GameComponent"/>
        /// </summary>
        protected GameComponent()
        {
            Enabled = true;
            Visible = true;
        }

        ~GameComponent()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool manualDispose)
        {
            if (manualDispose)
            {
                GC.SuppressFinalize(this);
                OnDispose();
            }
        }

        #region overrides

        /// <summary>
        /// Executed when this <see cref="GameComponent"/> is disposed by managed code
        /// </summary>
        protected virtual void OnDispose() {}

        /// <summary>
        /// Updates this <see cref="GameComponent"/>
        /// </summary>
        public virtual void Update() {}

        /// <summary>
        /// Renders this <see cref="GameComponent"/>
        /// </summary>
        public virtual void Render() {}

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if this <see cref="GameComponent"/> can be updated
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets if this <see cref="GameComponent"/> should be rendered
        /// </summary>
        public bool Visible { get; set; }

        #endregion
    }
}