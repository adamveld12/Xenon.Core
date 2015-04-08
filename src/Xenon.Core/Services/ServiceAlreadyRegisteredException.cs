using System;

namespace Xenon.Core.Services
{
    /// <summary>
    /// An error that occurs when a service has already been registered with a <see cref="GameServiceLocator"/>
    /// </summary>
    public class ServiceAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ServiceAlreadyRegisteredException"/>
        /// </summary>
        /// <param name="serviceType"></param>
        public ServiceAlreadyRegisteredException(Type serviceType) : base(String.Format("A service of type {0} is already registered.", serviceType))
        {
            
        }
    }

    /// <summary>
    /// An error that occurs when a service has not been registered with a <see cref="GameServiceLocator"/>
    /// </summary>
    public class ServiceNotRegisteredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ServiceNotRegisteredException"/>
        /// </summary>
        /// <param name="serviceType"></param>
        public ServiceNotRegisteredException(Type serviceType) : base(String.Format("A service of type {0} has not been registered.", serviceType))
        {
            
        }
    }
}