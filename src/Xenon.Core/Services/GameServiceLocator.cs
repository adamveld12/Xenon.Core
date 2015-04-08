using System;
using System.Collections.Generic;
using System.Linq;

namespace Xenon.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class GameServiceLocator : IServiceProvider, IGameServiceLocator
    {
        private readonly IDictionary<Type, object> _services;

        /// <summary>
        /// Initializes a new instance of <see cref="GameServiceLocator"/>
        /// </summary>
        public GameServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        /// </summary>
        ~GameServiceLocator() { Dispose(false); }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() { Dispose(true); }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
                _services.Values.OfType<IDisposable>().ForEach(x => x.Dispose());
            }
        }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <returns>
        /// A service object of type <paramref name="serviceType"/>.-or- null if there is no service object of type <paramref name="serviceType"/>.
        /// </returns>
        /// <param name="serviceType">An object that specifies the type of service object to get. </param>
        public object GetService(Type serviceType)
        {
            return _services[serviceType];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="service"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddService(Type type, object service)
        {
            if (!type.IsInstanceOfType(service))
                throw new InvalidOperationException();

            if (_services.ContainsKey(type))
                throw new ServiceAlreadyRegisteredException(type);

            _services.Add(type, service);
        }

        /// <summary>
        /// Gets an Enumerable of all services managed by the <see cref="GameServiceLocator"/>
        /// </summary>
        public IEnumerable<Object> Services
        {
            get { return _services.Values; }
        }
    }
}
