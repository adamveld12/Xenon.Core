using System;

namespace Xenon.Core
{
    /// <summary>
    /// Routes events to multiple handlers
    /// </summary>
    public interface IEventAggregator : IDisposable
    {
        /// <summary>
        /// Sends a message to all of the listeners
        /// </summary>
        /// <param name="message"></param>
        /// <typeparam name="TMessage"></typeparam>
        void SendMessage<TMessage>(TMessage message = default(TMessage)) where TMessage : struct;

        /// <summary>
        /// Subscribes a <see cref="IEventHandler{TEventType}"/> to this <see cref="IEventAggregator"/>
        /// </summary>
        /// <typeparam name="TEventType"></typeparam>
        void Subscribe<TEventType>(IEventHandler<TEventType> eventHandler) where TEventType : struct;

        /// <summary>
        /// Removes a subscription from the <see cref="IEventAggregator"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        /// <typeparam name="TEventType"></typeparam>
        void Unsubscribe<TEventType>(IEventHandler<TEventType> eventHandler) where TEventType : struct;

        /// <summary>
        /// Clears all subscriptions
        /// </summary>
        void Clear();
    }
}