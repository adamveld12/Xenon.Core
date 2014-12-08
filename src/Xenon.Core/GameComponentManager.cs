using System;
using System.Collections.Generic;
using System.Linq;

namespace Xenon.Core
{
    /// <summary>
    /// Manages <see cref="GameComponent"/>s lifecycle.
    /// This is basically a giant linked list of game components, the order in which you
    /// add them is the order in which they're updated
    /// </summary>
    public sealed class GameComponentManager : IDisposable
    {
        private readonly LinkedList<GameComponent> _components;

        /// <summary>
        /// Initializes a new instance of <see cref="GameComponentManager"/>
        /// </summary>
        public GameComponentManager()
        {
            _components = new LinkedList<GameComponent>();
        }

        ~GameComponentManager() { Dispose(false); }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() { Dispose(true); }

        private void Dispose(bool managedDispose)
        {
            if (managedDispose)
            {
                GC.SuppressFinalize(this);
                _components.ForEach(component => component.Dispose() );
                _components.Clear(); 
            }
        }

        /// <summary>
        /// Adds a component to the beginning of the list
        /// </summary>
        /// <param name="component"></param>
        public void Prepend(GameComponent component)
        {
            lock(_components) _components.AddFirst(component);
        }

        /// <summary>
        /// Adds a component to the end of the list
        /// </summary>
        /// <param name="component"></param>
        public void Append(GameComponent component)
        {
            lock(_components) _components.AddLast(component);
        }

        /// <summary>
        /// Updates the <see cref="GameComponent"/>s 
        /// </summary>
        public void Update()
        {
            foreach (var gameComponent in _components.Where(x => x.Enabled))
                gameComponent.Update();
        }

        /// <summary>
        /// Renders the <see cref="GameComponent"/>s 
        /// </summary>
        public void Render()
        {
            foreach (var gameComponent in _components.Where(x => x.Visible))
                gameComponent.Render();
        }

        public override string ToString()
        {
            return _components.Select(x => x.GetType().Name).Aggregate("", (acc, item) => acc + item);
        }
    }
}
