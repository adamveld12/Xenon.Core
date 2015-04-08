using System;
using System.Collections.Generic;

namespace Xenon.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGameServiceLocator : IDisposable
    {
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <returns>
        /// A service object of type <paramref name="serviceType"/>.-or- null if there is no service object of type <paramref name="serviceType"/>.
        /// </returns>
        /// <param name="serviceType">An object that specifies the type of service object to get. </param>
        object GetService(Type serviceType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="service"></param>
        /// <exception cref="InvalidOperationException"></exception>
        void AddService(Type type, object service);

        /// <summary>
        /// Gets an Enumerable of all services managed by the <see cref="GameServiceLocator"/>
        /// </summary>
        IEnumerable<Object> Services { get; }
    }
}