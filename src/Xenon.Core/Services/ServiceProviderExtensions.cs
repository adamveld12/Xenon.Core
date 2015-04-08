using System;
using Xenon.Core.Services;

// so its available everywhere a top level namespace include is used
// ReSharper disable CheckNamespace
namespace Xenon.Core
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Gets a service from the <see cref="GameServiceLocator"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>(this IServiceProvider provider)
        {
            return (T)provider.GetService(typeof (T));
        }

        /// <summary>
        /// Adds a service to the <see cref="GameServiceLocator"/>, throwing if one already exists
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="service"></param>
        /// <typeparam name="T"></typeparam>
        public static void Add<T>(this IGameServiceLocator locator, T service) where T : class
        {
            locator.AddService(typeof(T), service);
        }
    }
}